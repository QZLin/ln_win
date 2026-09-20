using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace ln_win
{
    public partial class Main : Form
    {
        private bool previousRelativeState = true;

        public Main()
        {
            InitializeComponent();
            previousRelativeState = checkBoxRelativeMode.Checked;
            ApplyStartupArg();
        }

        private void ApplyStartupArg()
        {
            string[] args = Environment.GetCommandLineArgs();
            // args[0] 是可执行文件路径，args[1] 才是第一个参数
            if (args.Length < 2) return;

            string arg = args[1];
            try
            {
                string full = Path.GetFullPath(arg);
                if (File.Exists(full))
                {
                    // 收到的是文件，取所在目录
                    string? dir = Path.GetDirectoryName(full);
                    if (!string.IsNullOrEmpty(dir))
                    {
                        textBoxWorkdir.Text = dir;
                        Log($"启动参数为文件，workdir设为所在目录:{dir}", LogLevel.Info);
                    }
                }
                else
                {
                    // 目录（或尚不存在的路径按目录处理）
                    textBoxWorkdir.Text = full;
                    Log($"启动参数为路径，workdir设为:{full}", LogLevel.Info);
                }
            }
            catch (Exception ex)
            {
                Log($"启动参数无效:{ex.Message}", LogLevel.Warning);
            }
        }


        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool GetFileInformationByHandle(SafeFileHandle hFile, out BY_HANDLE_FILE_INFORMATION lpFileInformation);

        private void CheckBoxSymbolic_CheckedChanged(object? sender, EventArgs e)
        {
            if (checkBoxSymbolic.Checked)
            {
                checkBoxRelativeMode.Enabled = true;
                checkBoxRelativeMode.Checked = previousRelativeState;
            }
            else
            {
                previousRelativeState = checkBoxRelativeMode.Checked;
                checkBoxRelativeMode.Checked = false;
                checkBoxRelativeMode.Enabled = false;
            }
        }

        private void ButtonSelectFile_Click(object? sender, EventArgs e)
        {
            if ((ModifierKeys & Keys.Shift) == Keys.Shift)
            {
                using var fbd = new FolderBrowserDialog();
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    textBoxFile.Text = fbd.SelectedPath;
                }
            }
            else
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    textBoxFile.Text = openFileDialog1.FileName;
                }
            }
        }

        private void ButtonSelectWorkdir_Click(object? sender, EventArgs e)
        {
            using var fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                textBoxWorkdir.Text = fbd.SelectedPath;
            }
        }

        private void TextBoxFile_DragEnter(object? sender, DragEventArgs e)
        {
            if (e.Data?.GetDataPresent(DataFormats.FileDrop) == true)
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void TextBoxFile_DragDrop(object? sender, DragEventArgs e)
        {
            if (e.Data?.GetData(DataFormats.FileDrop) is string[] files && files.Length > 0)
            {
                textBoxFile.Text = files[0];
                CreateLink();
            }
        }

        private void TextBoxFile_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CreateLink();
                e.Handled = true;
            }
        }

        private void TextBoxWorkdir_DragEnter(object? sender, DragEventArgs e)
        {
            if (e.Data?.GetDataPresent(DataFormats.FileDrop) == true)
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void TextBoxWorkdir_DragDrop(object? sender, DragEventArgs e)
        {
            if (e.Data?.GetData(DataFormats.FileDrop) is string[] files && files.Length > 0)
            {
                if (Directory.Exists(files[0]))
                {
                    textBoxWorkdir.Text = files[0];
                }
                else
                {
                    Log("拖入的不是文件夹", LogLevel.Error);
                }
            }
        }

        private void CreateLink()
        {
            string target = textBoxFile.Text.Trim();
            string workdir = textBoxWorkdir.Text.Trim();
            bool symbolic = checkBoxSymbolic.Checked;
            bool relative = checkBoxRelativeMode.Checked && symbolic;

            if (string.IsNullOrEmpty(target))
            {
                Log("请输入目标路径");
                return;
            }
            if (string.IsNullOrEmpty(workdir))
            {
                Log("请输入工作目录");
                return;
            }

            // 转换为绝对路径
            try
            {
                target = Path.GetFullPath(target);
                workdir = Path.GetFullPath(workdir);
            }
            catch (Exception ex)
            {
                Log($"路径无效:{ex.Message}", LogLevel.Error);
                return;
            }

            if (!File.Exists(target) && !Directory.Exists(target))
            {
                Log($"目标不存在:{target}", LogLevel.Warning);
                return;
            }
            if (!Directory.Exists(workdir))
            {
                Log($"工作目录不存在:{workdir}", LogLevel.Error);
                return;
            }

            string linkName = Path.GetFileName(target);
            string linkPath = Path.Combine(workdir, linkName);

            // 如果链接已存在
            if (File.Exists(linkPath) || Directory.Exists(linkPath))
            {
                if (checkBoxForce.Checked)
                {
                    bool isLink = IsLink(linkPath);
                    if (!isLink)
                    {
                        Log($"路径已存在且不是链接，无法强制重建:{linkPath}", LogLevel.Error);
                        return;
                    }
                    try
                    {
                        if (Directory.Exists(linkPath))
                            Directory.Delete(linkPath, false);
                        else
                            File.Delete(linkPath);
                        Log($"已删除现有链接:{linkPath}", LogLevel.Info);
                    }
                    catch (Exception ex)
                    {
                        Log($"删除现有链接失败:{ex.Message}", LogLevel.Error);
                        return;
                    }
                }
                else
                {
                    Log($"链接路径已存在:{linkPath}", LogLevel.Warning);
                    return;
                }
            }

            string finalTarget = target;
            if (symbolic && relative)
            {
                // 计算相对路径
                finalTarget = Path.GetRelativePath(workdir, target);
            }

            bool isDirectory = Directory.Exists(target);
            Log($"创建链接:类型={(symbolic ? "SYMLINK" : (isDirectory ? "JUNCTION" : "HARDLINK"))}, 目标={finalTarget}, 链接={linkPath}", LogLevel.Info);

            try
            {
                if (symbolic)
                {
                    // 使用 .NET API 创建符号链接
                    if (isDirectory)
                    {
                        Directory.CreateSymbolicLink(linkPath, finalTarget);
                    }
                    else
                    {
                        File.CreateSymbolicLink(linkPath, finalTarget);
                    }
                    Log($"创建成功:{linkPath}", LogLevel.Info);
                }
                else
                {
                    // 使用 mklink 创建硬链接或联接
                    string mklinkArgs = isDirectory ? $"/J \"{linkPath}\" \"{finalTarget}\"" : $"/H \"{linkPath}\" \"{finalTarget}\"";
                    var psi = new ProcessStartInfo
                    {
                        FileName = "cmd.exe",
                        Arguments = $"/c mklink {mklinkArgs}",
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        CreateNoWindow = true
                    };
                    using var process = Process.Start(psi);
                    string output = process!.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();
                    process.WaitForExit();
                    if (process.ExitCode == 0)
                    {
                        Log($"创建成功:{linkPath}", LogLevel.Info);
                    }
                    else
                    {
                        Log($"创建失败:{error}", LogLevel.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                Log($"异常:{ex.Message}", LogLevel.Error);
            }
        }

        private static bool IsLink(string path)
        {
            // 检查重解析点（符号链接、联接点）
            FileAttributes attrs = File.GetAttributes(path);
            if ((attrs & FileAttributes.ReparsePoint) != 0)
                return true;

            // 如果是目录且非重解析点，则是普通目录
            if (Directory.Exists(path))
                return false;

            // 文件：检查硬链接计数
            try
            {
                using SafeFileHandle handle = File.OpenHandle(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite | FileShare.Delete);
                if (GetFileInformationByHandle(handle, out BY_HANDLE_FILE_INFORMATION info))
                {
                    // 硬链接数大于1说明是硬链接
                    return info.NumberOfLinks > 1;
                }
            }
            catch
            {
                // 忽略，无法判断则视为非链接
            }
            return false;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct BY_HANDLE_FILE_INFORMATION
        {
            public uint FileAttributes;
            public System.Runtime.InteropServices.ComTypes.FILETIME CreationTime;
            public System.Runtime.InteropServices.ComTypes.FILETIME LastAccessTime;
            public System.Runtime.InteropServices.ComTypes.FILETIME LastWriteTime;
            public uint VolumeSerialNumber;
            public uint FileSizeHigh;
            public uint FileSizeLow;
            public uint NumberOfLinks;
            public uint FileIndexHigh;
            public uint FileIndexLow;
        }

        enum LogLevel
        {
            Debug,
            Info,
            Warning,
            Error
        }
        private void Log(string message)
        {
            richTextBoxLogger.AppendText($"{DateTime.Now:HH:mm:ss} {message}{Environment.NewLine}");
        }
        private void Log(string message, LogLevel level)
        {
            if (level >= LogLevel.Info)
            {
                richTextBoxLogger.AppendText($"{DateTime.Now:HH:mm:ss} [{level}] {message}{Environment.NewLine}");
            }
        }
    }
}

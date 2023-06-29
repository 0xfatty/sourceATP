using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Text;
using System.Windows.Forms;
using GetTokenFromLd.Properties;
using Microsoft.Win32;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.Default | DebuggableAttribute.DebuggingModes.DisableOptimizations | DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints | DebuggableAttribute.DebuggingModes.EnableEditAndContinue)]
[assembly: AssemblyTitle("GetTokenFromLd")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("GetTokenFromLd")]
[assembly: AssemblyCopyright("Copyright ©  2020")]
[assembly: AssemblyTrademark("")]
[assembly: ComVisible(false)]
[assembly: Guid("13903dea-89dc-4c87-8cd3-d434cd848195")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: TargetFramework(".NETFramework,Version=v4.5", FrameworkDisplayName = ".NET Framework 4.5")]
[assembly: AssemblyVersion("1.0.0.0")]
namespace GetTokenFromLd
{
	public class Form1 : Form
	{
		private ldplayerControll ld;

		private IContainer components = null;

		private Button button1;

		private ComboBox comboBox1;

		private Button button2;

		private RichTextBox textBox1;

		private Label label1;

		private RichTextBox richTextBox1;

		private Label label2;

		private Label label3;

		private PictureBox pictureBox1;

		private LinkLabel linkLabel1;

		private Label label4;

		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			//IL_015f: Unknown result type (might be due to invalid IL or missing references)
			string text = File.ReadAllText("LDPlayer.conf");
			if (!File.Exists(text + "//dnconsole.exe"))
			{
				text = "";
				string text2 = "";
				text2 = ((!Environment.Is64BitOperatingSystem) ? "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall" : "SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Uninstall");
				using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(text2))
				{
					string[] subKeyNames = registryKey.GetSubKeyNames();
					foreach (string name in subKeyNames)
					{
						using RegistryKey registryKey2 = registryKey.OpenSubKey(name);
						if (registryKey2.GetValue("DisplayName") != null && registryKey2.GetValue("DisplayName").ToString().Contains("LDPlayer"))
						{
							string text3 = registryKey2.GetValue("UninstallString").ToString();
							string text4 = text3.Substring(0, text3.LastIndexOf("\\"));
							if (File.Exists(text4 + "//dnconsole.exe"))
							{
								text = text4;
								File.WriteAllText("LDPlayer.conf", text4);
							}
						}
					}
				}
				if (text == "")
				{
					MessageBox.Show("Chúng tôi không tìm thấy phần mềm giả lập LDPlayer, hãy truy cập https://vn.ldplayer.net đề cài và sau đó bật phần mềm lại.");
				}
			}
			ld = new ldplayerControll(text, Path.GetDirectoryName(Application.ExecutablePath));
			string text5 = ld.list();
			string[] array = text5.Split(new string[1] { "\r\n" }, StringSplitOptions.None);
			bool flag = false;
			string text6 = ld.runninglist();
			string[] array2 = text6.Split(new string[1] { "\r\n" }, StringSplitOptions.None);
			ObjectCollection items = comboBox1.Items;
			object[] array3 = array2;
			items.AddRange(array3);
			((ListControl)comboBox1).SelectedIndex = 0;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			//IL_015f: Unknown result type (might be due to invalid IL or missing references)
			string text = File.ReadAllText("LDPlayer.conf");
			if (!File.Exists(text + "//dnconsole.exe"))
			{
				text = "";
				string text2 = "";
				text2 = ((!Environment.Is64BitOperatingSystem) ? "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall" : "SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Uninstall");
				using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(text2))
				{
					string[] subKeyNames = registryKey.GetSubKeyNames();
					foreach (string name in subKeyNames)
					{
						using RegistryKey registryKey2 = registryKey.OpenSubKey(name);
						if (registryKey2.GetValue("DisplayName") != null && registryKey2.GetValue("DisplayName").ToString().Contains("LDPlayer"))
						{
							string text3 = registryKey2.GetValue("UninstallString").ToString();
							string text4 = text3.Substring(0, text3.LastIndexOf("\\"));
							if (File.Exists(text4 + "//dnconsole.exe"))
							{
								text = text4;
								File.WriteAllText("LDPlayer.conf", text4);
							}
						}
					}
				}
				if (text == "")
				{
					MessageBox.Show("Chúng tôi không tìm thấy phần mềm giả lập LDPlayer, hãy truy cập https://vn.ldplayer.net đề cài và sau đó bật phần mềm lại.");
				}
			}
			ld = new ldplayerControll(text, Path.GetDirectoryName(Application.ExecutablePath));
			string text5 = (string)comboBox1.Items[((ListControl)comboBox1).SelectedIndex];
			StringBuilder stringBuilder = new StringBuilder();
			string text6 = text5;
			foreach (char c in text6)
			{
				if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_')
				{
					stringBuilder.Append(c);
				}
			}
			string text7 = stringBuilder.ToString();
			string text8 = ld.pull(text5, text7);
			if (File.Exists("C:\\" + text7))
			{
				string text9 = File.ReadAllText("C:\\" + text7);
				if (text9.Contains("EAAA"))
				{
					string[] array = text9.Split(new string[1] { "EAA" }, StringSplitOptions.None);
					string text10 = array[1];
					string[] array2 = text10.Split(new string[1] { "\u0005" }, StringSplitOptions.None);
					string text11 = "EAA" + array2[0];
					((Control)textBox1).Text = text11;
					File.WriteAllText("C:\\auth2", "");
				}
				else
				{
					((Control)textBox1).Text = "";
				}
			}
			else
			{
				((Control)textBox1).Text = "";
			}
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			//IL_0167: Unknown result type (might be due to invalid IL or missing references)
			string text = File.ReadAllText("LDPlayer.conf");
			if (!File.Exists(text + "//dnconsole.exe"))
			{
				text = "";
				string text2 = "";
				text2 = ((!Environment.Is64BitOperatingSystem) ? "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall" : "SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Uninstall");
				using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(text2))
				{
					string[] subKeyNames = registryKey.GetSubKeyNames();
					foreach (string name in subKeyNames)
					{
						using RegistryKey registryKey2 = registryKey.OpenSubKey(name);
						if (registryKey2.GetValue("DisplayName") != null && registryKey2.GetValue("DisplayName").ToString().Contains("LDPlayer"))
						{
							string text3 = registryKey2.GetValue("UninstallString").ToString();
							string text4 = text3.Substring(0, text3.LastIndexOf("\\"));
							if (File.Exists(text4 + "//dnconsole.exe"))
							{
								text = text4;
								((Control)richTextBox1).Text = text;
								File.WriteAllText("LDPlayer.conf", text4);
							}
						}
					}
				}
				if (text == "")
				{
					MessageBox.Show("Chúng tôi không tìm thấy phần mềm giả lập LDPlayer, hãy truy cập https://vn.ldplayer.net đề cài và sau đó bật phần mềm lại.");
				}
			}
			else
			{
				((Control)richTextBox1).Text = text;
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			((Form)this).Dispose(disposing);
		}

		private void InitializeComponent()
		{
			//IL_0012: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Expected O, but got Unknown
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Expected O, but got Unknown
			//IL_0028: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Expected O, but got Unknown
			//IL_0033: Unknown result type (might be due to invalid IL or missing references)
			//IL_003d: Expected O, but got Unknown
			//IL_003e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0048: Expected O, but got Unknown
			//IL_0049: Unknown result type (might be due to invalid IL or missing references)
			//IL_0053: Expected O, but got Unknown
			//IL_0054: Unknown result type (might be due to invalid IL or missing references)
			//IL_005e: Expected O, but got Unknown
			//IL_005f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0069: Expected O, but got Unknown
			//IL_006a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0074: Expected O, but got Unknown
			//IL_0075: Unknown result type (might be due to invalid IL or missing references)
			//IL_007f: Expected O, but got Unknown
			//IL_0080: Unknown result type (might be due to invalid IL or missing references)
			//IL_008a: Expected O, but got Unknown
			//IL_0131: Unknown result type (might be due to invalid IL or missing references)
			//IL_013b: Expected O, but got Unknown
			//IL_0238: Unknown result type (might be due to invalid IL or missing references)
			//IL_0242: Expected O, but got Unknown
			//IL_032b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0335: Expected O, but got Unknown
			//IL_0501: Unknown result type (might be due to invalid IL or missing references)
			//IL_050b: Expected O, but got Unknown
			//IL_059c: Unknown result type (might be due to invalid IL or missing references)
			//IL_05a6: Expected O, but got Unknown
			//IL_0710: Unknown result type (might be due to invalid IL or missing references)
			//IL_071a: Expected O, but got Unknown
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Form1));
			button1 = new Button();
			comboBox1 = new ComboBox();
			button2 = new Button();
			textBox1 = new RichTextBox();
			label1 = new Label();
			richTextBox1 = new RichTextBox();
			label2 = new Label();
			label3 = new Label();
			pictureBox1 = new PictureBox();
			linkLabel1 = new LinkLabel();
			label4 = new Label();
			((ISupportInitialize)pictureBox1).BeginInit();
			((Control)this).SuspendLayout();
			((Control)button1).Location = new Point(12, 76);
			((Control)button1).Name = "button1";
			((Control)button1).Size = new Size(604, 36);
			((Control)button1).TabIndex = 1;
			((Control)button1).Text = "Quét ds máy ảo";
			((ButtonBase)button1).UseVisualStyleBackColor = true;
			((Control)button1).Click += button1_Click;
			((Control)comboBox1).Font = new Font("Microsoft Sans Serif", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
			((ListControl)comboBox1).FormattingEnabled = true;
			((Control)comboBox1).Location = new Point(12, 118);
			((Control)comboBox1).Name = "comboBox1";
			((Control)comboBox1).Size = new Size(604, 28);
			((Control)comboBox1).TabIndex = 2;
			((Control)button2).Location = new Point(13, 178);
			((Control)button2).Name = "button2";
			((Control)button2).Size = new Size(604, 37);
			((Control)button2).TabIndex = 3;
			((Control)button2).Text = "GET TOKEN";
			((ButtonBase)button2).UseVisualStyleBackColor = true;
			((Control)button2).Click += button2_Click;
			((TextBoxBase)textBox1).BorderStyle = (BorderStyle)1;
			((Control)textBox1).Font = new Font("Microsoft Sans Serif", 13f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
			((Control)textBox1).Location = new Point(13, 221);
			((Control)textBox1).Name = "textBox1";
			((Control)textBox1).Size = new Size(604, 106);
			((Control)textBox1).TabIndex = 4;
			((Control)textBox1).Text = "";
			((Control)label1).AutoSize = true;
			((Control)label1).Location = new Point(12, 9);
			((Control)label1).Name = "label1";
			((Control)label1).Size = new Size(142, 13);
			((Control)label1).TabIndex = 5;
			((Control)label1).Text = "1. Thư mục cài đặt LDplayer";
			((TextBoxBase)richTextBox1).BorderStyle = (BorderStyle)1;
			((Control)richTextBox1).Font = new Font("Microsoft Sans Serif", 13f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
			((Control)richTextBox1).Location = new Point(12, 25);
			((Control)richTextBox1).Name = "richTextBox1";
			((Control)richTextBox1).Size = new Size(604, 25);
			((Control)richTextBox1).TabIndex = 6;
			((Control)richTextBox1).Text = "";
			((Control)label2).AutoSize = true;
			((Control)label2).Location = new Point(12, 60);
			((Control)label2).Name = "label2";
			((Control)label2).Size = new Size(237, 13);
			((Control)label2).TabIndex = 7;
			((Control)label2).Text = "2. Chọn máy ảo đã login facebook cần lấy token";
			((Control)label3).AutoSize = true;
			((Control)label3).Location = new Point(12, 156);
			((Control)label3).Name = "label3";
			((Control)label3).Size = new Size(162, 13);
			((Control)label3).TabIndex = 8;
			((Control)label3).Text = "3. Lấy token full quyền facebook";
			((Control)pictureBox1).BackgroundImage = (Image)(object)Resources.logo_atpsoftware_500;
			((Control)pictureBox1).BackgroundImageLayout = (ImageLayout)3;
			((Control)pictureBox1).Location = new Point(15, 333);
			((Control)pictureBox1).Name = "pictureBox1";
			((Control)pictureBox1).Size = new Size(214, 83);
			pictureBox1.TabIndex = 9;
			pictureBox1.TabStop = false;
			((Control)linkLabel1).AutoSize = true;
			((Control)linkLabel1).Font = new Font("Microsoft Sans Serif", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
			((Control)linkLabel1).Location = new Point(250, 360);
			((Control)linkLabel1).Name = "linkLabel1";
			((Control)linkLabel1).Size = new Size(141, 18);
			((Control)linkLabel1).TabIndex = 10;
			linkLabel1.TabStop = true;
			((Control)linkLabel1).Text = "www.atpsoftware.vn";
			((Control)label4).AutoSize = true;
			((Control)label4).Font = new Font("Microsoft Sans Serif", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
			((Control)label4).Location = new Point(246, 337);
			((Control)label4).Name = "label4";
			((Control)label4).Size = new Size(253, 20);
			((Control)label4).TabIndex = 11;
			((Control)label4).Text = "CÔNG TY TNHH ATPSOFTWARE";
			((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
			((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
			((Form)this).ClientSize = new Size(627, 433);
			((Control)this).Controls.Add((Control)(object)label4);
			((Control)this).Controls.Add((Control)(object)linkLabel1);
			((Control)this).Controls.Add((Control)(object)pictureBox1);
			((Control)this).Controls.Add((Control)(object)label3);
			((Control)this).Controls.Add((Control)(object)label2);
			((Control)this).Controls.Add((Control)(object)richTextBox1);
			((Control)this).Controls.Add((Control)(object)label1);
			((Control)this).Controls.Add((Control)(object)textBox1);
			((Control)this).Controls.Add((Control)(object)button2);
			((Control)this).Controls.Add((Control)(object)comboBox1);
			((Control)this).Controls.Add((Control)(object)button1);
			((Form)this).Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			((Control)this).Name = "Form1";
			((Control)this).Text = "GET TOKEN  FULL - ATPSOFTWARE.VN";
			((Form)this).Load += Form1_Load;
			((ISupportInitialize)pictureBox1).EndInit();
			((Control)this).ResumeLayout(false);
			((Control)this).PerformLayout();
		}
	}
	internal class ldplayerControll
	{
		public string path;

		public string folder;

		public string localFolder;

		public ldplayerControll(string cPath, string clocalFolder)
		{
			path = cPath + "\\dnconsole.exe";
			folder = cPath;
			localFolder = clocalFolder;
		}

		public string exec(string command)
		{
			Process process = new Process();
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.RedirectStandardOutput = true;
			process.StartInfo.RedirectStandardError = true;
			process.StartInfo.CreateNoWindow = true;
			process.StartInfo.FileName = path;
			process.StartInfo.Arguments = command;
			process.Start();
			process.WaitForExit();
			return process.StandardOutput.ReadToEnd();
		}

		public void exec2(string command)
		{
			Process process = new Process();
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.RedirectStandardOutput = true;
			process.StartInfo.RedirectStandardError = true;
			process.StartInfo.CreateNoWindow = true;
			process.StartInfo.FileName = path;
			process.StartInfo.Arguments = command;
			process.Start();
			process.WaitForExit();
		}

		public string execAdb(string name, string command)
		{
			Process process = new Process();
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.RedirectStandardOutput = true;
			process.StartInfo.RedirectStandardError = true;
			process.StartInfo.CreateNoWindow = true;
			process.StartInfo.FileName = path;
			string arguments = "adb --name " + name + " --command \"" + command + "\"";
			process.StartInfo.Arguments = arguments;
			process.Start();
			process.WaitForExit(500);
			return process.StandardOutput.ReadToEnd();
		}

		public string execAdb2(string name, string command)
		{
			Process process = new Process();
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.RedirectStandardOutput = true;
			process.StartInfo.RedirectStandardError = true;
			process.StartInfo.CreateNoWindow = true;
			process.StartInfo.FileName = path;
			string arguments = "adb --name " + name + " --command '" + command + "'";
			process.StartInfo.Arguments = arguments;
			process.Start();
			process.WaitForExit(200);
			return process.StandardOutput.ReadToEnd();
		}

		public MemoryStream execAdbGetStream(string name, string command)
		{
			Process process = new Process();
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.RedirectStandardOutput = true;
			process.StartInfo.RedirectStandardError = true;
			process.StartInfo.CreateNoWindow = true;
			process.StartInfo.FileName = path;
			string arguments = "adb --name " + name + " --command \"" + command + "\"";
			process.StartInfo.Arguments = arguments;
			process.Start();
			MemoryStream memoryStream = new MemoryStream();
			process.StandardOutput.BaseStream.CopyTo(memoryStream);
			return memoryStream;
		}

		public string list()
		{
			return exec("list");
		}

		public string runninglist()
		{
			return exec("runninglist");
		}

		public string pull(string name, string fileName)
		{
			string command = "pull --name " + name + " --remote \"/data/data/com.facebook.katana/app_light_prefs/com.facebook.katana/authentication\" --local \"C:\\" + fileName + "\"";
			return exec(command);
		}

		public void create(string name, string cPath)
		{
			exec(" add --name " + name);
		}

		public void restore(string name, string cPath)
		{
			exec2("restore --name " + name + " --file \"" + cPath + "//source.ldbk\"");
		}

		public void modify(string name, string cPath)
		{
			exec(" rename --name ins:duc_nguyen --title " + name);
			exec(" modify --name " + name + " --resolution 320,480,120 --manufacturer asus --model ASUS_Z00DUO --pnumber auto --imei auto --imsi auto --simserial auto --androidid auto --mac auto");
		}

		public bool isRunning(string name)
		{
			string text = execAdb(name, "shell ls");
			if (text.Contains("error: device not found"))
			{
				return false;
			}
			return true;
		}

		public bool isRunning2(string name)
		{
			string text = exec("isrunning --name " + name);
			if (text == "running")
			{
				return true;
			}
			return false;
		}

		public void start(string name)
		{
			exec("launch --name " + name);
		}

		public bool checkLogin(string name)
		{
			execAdb(name, "shell am start -a android.intent.action.VIEW -d https://www.instagram.com/thisishoangg/");
			execAdb(name, "shell uiautomator dump");
			string command = "shell cat /storage/emulated/legacy/window_dump.xml";
			string text = execAdb(name, command);
			if (text.Contains("login_username"))
			{
				return false;
			}
			return true;
		}

		private void clear_input(string name)
		{
			execAdb(name, "shell input keyevent KEYCODE_MOVE_END");
			for (int i = 0; i < 20; i++)
			{
				execAdb(name, "shell input keyevent --longpress KEYCODE_DEL");
			}
		}

		public void loginInstagram(string name, string username, string password)
		{
			execAdb(name, "shell am start -a android.intent.action.VIEW -d https://www.instagram.com/thisishoangg/");
			execAdb(name, "shell input tap 21 158");
			clear_input(name);
			execAdb(name, "shell input text " + username);
			execAdb(name, "shell input tap 21 205");
			execAdb(name, "shell input text " + password);
			execAdb(name, "shell input tap 21 253");
		}

		public void openProfileFollow(string name, string user_name)
		{
			execAdb(name, "shell am start -a android.intent.action.VIEW -d https://www.instagram.com/" + user_name + "/");
		}

		public void openPost(string name, string url_post)
		{
			execAdb(name, "shell am start -a android.intent.action.VIEW -d " + url_post);
		}

		public void openInstagram(string name)
		{
			execAdb(name, "shell am start -a android.intent.action.VIEW -d https://www.instagram.com/");
		}

		public void dump(string name)
		{
			execAdb(name, "shell uiautomator dump");
		}

		public void searchCloseFriend(string name, string user_name)
		{
			execAdb(name, "shell input tap 45 163");
			execAdb(name, "shell input text " + user_name);
		}

		public void quitCloesFriend(string name)
		{
			execAdb(name, "shell input tap 291 34");
			execAdb(name, "shell input tap 160 302");
		}

		public void addCloesFriend(string name)
		{
			execAdb(name, "shell input tap 276 73");
		}

		public void openHome(string name)
		{
			execAdb(name, "shell input tap 286 462");
		}

		public bool checkOpeInstagram(string name)
		{
			Random random = new Random();
			int num = random.Next(111111111, 999999999);
			int num2 = random.Next(111111111, 999999999);
			string text = num + "_" + num2;
			string text2 = folder + "\\res\\" + text + ".xml";
			File.Delete(text2);
			string command = "pull /storage/emulated/legacy/window_dump.xml " + text2;
			string text3 = execAdb(name, command);
			string text4 = File.ReadAllText(text2);
			if (text4.Contains("com.instagram.android"))
			{
				return true;
			}
			return false;
		}

		public int like(string name, string user_name)
		{
			string command = "shell cat /storage/emulated/legacy/window_dump.xml";
			string text = execAdb(name, command);
			if (text.Contains("row_feed_button_like"))
			{
				string[] array = text.Split(new string[1] { "row_feed_button_like" }, StringSplitOptions.None);
				string[] array2 = array[1].Split(new string[1] { "]" }, StringSplitOptions.None);
				string[] array3 = array2[1].Split(new string[1] { "," }, StringSplitOptions.None);
				int result = int.Parse(array3[1]) - 20;
				execAdb(name, "shell input tap 15 " + result);
				return result;
			}
			return 0;
		}

		public int follow(string name, string user_name)
		{
			Random random = new Random();
			int num = random.Next(111111111, 999999999);
			int num2 = random.Next(111111111, 999999999);
			string text = num + "_" + num2;
			string text2 = folder + "\\res\\" + text + ".xml";
			File.Delete(text2);
			string command = "pull /storage/emulated/legacy/window_dump.xml " + text2;
			string text3 = execAdb(name, command);
			string text4 = File.ReadAllText(text2);
			if (text4.Contains("row_profile_header_button_follow") && text4.Contains("text=\"Follow\""))
			{
				string[] array = text4.Split(new string[1] { "row_profile_header_button_follow" }, StringSplitOptions.None);
				string[] array2 = array[1].Split(new string[1] { "]" }, StringSplitOptions.None);
				string[] array3 = array2[0].Split(new string[1] { "," }, StringSplitOptions.None);
				int result = int.Parse(array3[1]);
				execAdb(name, "shell input tap 110 " + result);
				return result;
			}
			return 0;
		}

		public bool openMenu(string name)
		{
			execAdb(name, "shell input tap 300 32");
			return true;
		}

		public bool openCloseFriend(string name)
		{
			Random random = new Random();
			int num = random.Next(111111111, 999999999);
			int num2 = random.Next(111111111, 999999999);
			string text = num + "_" + num2;
			string text2 = folder + "\\res\\" + text + ".xml";
			File.Delete(text2);
			string command = "pull /storage/emulated/legacy/window_dump.xml " + text2;
			string text3 = execAdb(name, command);
			string text4 = File.ReadAllText(text2);
			if (text4.Contains("Close Friends"))
			{
				string[] array = text4.Split(new string[1] { "Close Friends" }, StringSplitOptions.None);
				string[] array2 = array[1].Split(new string[1] { "]" }, StringSplitOptions.None);
				string[] array3 = array2[0].Split(new string[1] { "," }, StringSplitOptions.None);
				execAdb(name, "shell input tap 128 " + int.Parse(array3[1]));
				return true;
			}
			return false;
		}

		public bool openRelationship(string name, int _y)
		{
			execAdb(name, "shell input tap 33 " + _y);
			return true;
		}

		public bool addRelationship(string name, string user_name)
		{
			Random random = new Random();
			int num = random.Next(111111111, 999999999);
			int num2 = random.Next(111111111, 999999999);
			string text = num + "_" + num2;
			string text2 = folder + "\\res\\" + text + ".xml";
			File.Delete(text2);
			string command = "pull /storage/emulated/legacy/window_dump.xml " + text2;
			string text3 = execAdb(name, command);
			string text4 = File.ReadAllText(text2);
			if (text4.Contains("profile_follow_relationship_row_title"))
			{
				string[] array = text4.Split(new string[1] { "profile_follow_relationship_row_title" }, StringSplitOptions.None);
				string[] array2 = array[1].Split(new string[1] { "]" }, StringSplitOptions.None);
				string[] array3 = array2[0].Split(new string[1] { "," }, StringSplitOptions.None);
				execAdb(name, "shell input tap 33 " + int.Parse(array3[1]));
				return true;
			}
			return false;
		}

		public bool unfollow(string name, string user_name)
		{
			string command = "shell cat /storage/emulated/legacy/window_dump.xml";
			string text = execAdb(name, command);
			if (text.Contains("Following"))
			{
				string[] array = text.Split(new string[1] { "text=\"Following\"" }, StringSplitOptions.None);
				if (array.Length == 2)
				{
					if (text.Contains("Message"))
					{
						string[] array2 = text.Split(new string[1] { "text=\"Message\"" }, StringSplitOptions.None);
						string[] array3 = array2[1].Split(new string[1] { "]" }, StringSplitOptions.None);
						string[] array4 = array3[2].Split(new string[1] { "[" }, StringSplitOptions.None);
						string[] array5 = array4[1].Split(new string[1] { "," }, StringSplitOptions.None);
						int num = int.Parse(array5[0]) + 7;
						int num2 = int.Parse(array5[1]);
						execAdb(name, "shell input tap " + num + " " + num2);
						execAdb(name, "shell input tap 221 324");
						return true;
					}
					return false;
				}
				string[] array6 = array[2].Split(new string[1] { "]" }, StringSplitOptions.None);
				string[] array7 = array6[0].Split(new string[1] { "[" }, StringSplitOptions.None);
				string[] array8 = array7[1].Split(new string[1] { "," }, StringSplitOptions.None);
				int num3 = int.Parse(array8[0]) + 7;
				int num4 = int.Parse(array8[1]);
				execAdb(name, "shell input tap " + num3 + " " + num4);
				execAdb(name, "shell input tap 7 393");
				execAdb(name, "shell input tap 160 307");
				return true;
			}
			return false;
		}

		public void closeIns(string name)
		{
			execAdb(name, "shell am force-stop com.instagram.android");
			execAdb(name, "shell am force-stop com.android.vending");
			execAdb(name, "shell am force-stop com.android.browser");
			execAdb(name, "shell am force-stop com.google.process.gapps");
			execAdb(name, "shell am force-stop com.android.ld.appstore");
		}
	}
	internal static class Program
	{
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run((Form)(object)new Form1());
		}
	}
}
namespace GetTokenFromLd.Properties
{
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal class Resources
	{
		private static ResourceManager resourceMan;

		private static CultureInfo resourceCulture;

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (resourceMan == null)
				{
					ResourceManager resourceManager = new ResourceManager("GetTokenFromLd.Properties.Resources", typeof(Resources).Assembly);
					resourceMan = resourceManager;
				}
				return resourceMan;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return resourceCulture;
			}
			set
			{
				resourceCulture = value;
			}
		}

		internal static Bitmap logo_atpsoftware_500
		{
			get
			{
				//IL_0017: Unknown result type (might be due to invalid IL or missing references)
				//IL_001d: Expected O, but got Unknown
				object @object = ResourceManager.GetObject("logo-atpsoftware-500", resourceCulture);
				return (Bitmap)@object;
			}
		}

		internal Resources()
		{
		}
	}
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0")]
	internal sealed class Settings : ApplicationSettingsBase
	{
		private static Settings defaultInstance = (Settings)(object)SettingsBase.Synchronized((SettingsBase)(object)new Settings());

		public static Settings Default => defaultInstance;
	}
}

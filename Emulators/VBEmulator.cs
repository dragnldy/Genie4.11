using GenieClient.Genie;
using System;
using System.Windows.Forms;

namespace Emulators
{
    public enum AppWinStyle
    {
        NormalFocus,
        MinimizedFocus,
        Hidden,
        MaximizedFocus,
        MinimizedNoFocus,
        NormalNoFocus
    }
    public static class Conversions
    {
        public static DateTime ToDate(object value)
        {
            if (value == null) return DateTime.MinValue;
            if (value is DateTime dt) return dt;
            if (value is string str && DateTime.TryParse(str, out dt)) return dt;
            if (value is int i) return new DateTime(1970, 1, 1).AddSeconds(i);
            throw new InvalidCastException($"Cannot convert {value.GetType()} to Date.");
        }
        public static char ToChar(object value)
        {
            if (value == null) return Constants.vbNullChar;
            if (value is char c) return c;
            if (value is string str && str.Length > 0) return str[0];
            if (value is int i && i >= 0 && i <= 65535) return (char)i;
            throw new InvalidCastException($"Cannot convert {value.GetType()} to Char.");
        }
        public static bool ToBoolean(object value)
        {
            if (value == null) return false;
            if (value is bool b) return b;
            if (value is int i) return i != 0;
            if (value is double d) return d != 0.0;
            if (value is string str)
            {
                return str.Equals("True", StringComparison.OrdinalIgnoreCase) || str.Equals("1");
            }
            throw new InvalidCastException($"Cannot convert {value.GetType()} to Boolean.");
        }
        public static int ToInteger(object value)
        {
            if (value == null) return 0;
            if (value is int i) return i;
            if (value is double d) return (int)d;
            if (value is string str && int.TryParse(str, out i)) return i;
            throw new InvalidCastException($"Cannot convert {value.GetType()} to Integer.");
        }
        public static string ToString(object c)
        {
            return c != null ?c.ToString() : string.Empty;
        }
        //public static string ToString(char c)
        //{
        //    return c.ToString();
        //}
        //public static string ToString(int i)
        //{
        //    return i.ToString();
        //}
        //public static string ToString(double d)
        //{
        //    return d.ToString();
        //}
        public static string ToString(bool b)
        {
            return b ? "True" : "False";
        }
    }
    public static class Information
    {
        public static bool IsNumeric(object value)
        {
            if (value == null) return false;
            if (value is int || value is double || value is float || value is decimal) return true;
            if (value is string str)
            {
                return double.TryParse(str, out _);
            }
            return false;
        }
        public static bool IsNothing(object obj)
        {
            return obj == null || (obj is string str && string.IsNullOrEmpty(str));
        }
    }
    public static class Interaction
    {
        public static object IIf(bool condition, object truePart, object falsePart)
        {
            return condition ? truePart : falsePart;
        }
        public static void Beep()
        {
            // This is a placeholder for a beep implementation.
            // In a real application, you would use a sound library to play a beep.
            System.Media.SystemSounds.Beep.Play();
//            Console.Beep();
        }
        public static void Shell(string commandPlusArgs, AppWinStyle style, bool hrmmm)
        {
            // This is a placeholder for a shell implementation.
            // We don't currently use the style or hrmmm parameters.- just there to maintain compatibility
            var parts = commandPlusArgs.Split(new[] { ' ' }, 2);
            if (parts.Length == 0 || parts.Length > 2)
            {
                throw new ArgumentException("Command should not contain more than one space but should contain at least a command.");
            }
            string command = parts[0];
            string args = parts.Length > 1 ? parts[1] : string.Empty;
            System.Diagnostics.Process.Start(command, args);
        }
        public static MsgBoxResult MsgBox(string message, MsgBoxStyle buttons = 0, string title = "Message")
        {
            MessageBoxButtons msgButtons= (MessageBoxButtons)buttons;
            // This is a placeholder for a message box implementation.
            var result = MessageBox.Show(message, title, msgButtons);
            switch (result)
            {
                case DialogResult.OK:
                    return MsgBoxResult.OK;
                case DialogResult.Cancel:
                    return MsgBoxResult.Cancel;
                case DialogResult.Abort:
                    return MsgBoxResult.Abort;
                case DialogResult.Retry:
                    return MsgBoxResult.Retry;
                case DialogResult.Ignore:
                    return MsgBoxResult.Ignore;
                case DialogResult.Yes:
                    return MsgBoxResult.Yes;
                case DialogResult.No:
                    return MsgBoxResult.No;
            }
            return MsgBoxResult.OK;
        }
        public const string[] commandargs = null;
        public static string Command()
        {
            var args = Environment.GetCommandLineArgs();
            // return the command line arguments as a string array
            if (args.Length > 1)
            {
                string arg = string.Join(" ", args, 1, args.Length - 1);
                return arg;
            }
            return string.Empty;
        }

    }
    public enum  MsgBoxResult
    {
        OK = DialogResult.OK,
        Cancel = DialogResult.Cancel,
        Abort = DialogResult.Abort,
        Retry = DialogResult.Retry,
        Ignore = DialogResult.Ignore,
        Yes = DialogResult.Yes,
        No = DialogResult.No
    }
    public enum MsgBoxStyle
    {
        OkOnly = 0,
        OkCancel = 1,
        AbortRetryIgnore = 2,
        YesNoCancel = 3,
        YesNo = 4,
        RetryCancel = 5,
        Critical = 16,
        Question = 32,
        Exclamation = 48,
        Information = 64,
        DefaultButton1 = 0,
        DefaultButton2 = 256,
        DefaultButton3 = 512
    }
    public static class Constants
    {
        public const char vbNullChar = '\0';
        public const char vbTab = '\t';
        public const string vbCr = "\r";
        public const char vbNewLine = '\n';
        public const string vbLf = "\n";
        public const string vbCrLf = "\r\n";
        public const string vbArchive = "32";
        //public const int vbOKOnly = 0;
        //public const int vbOKCancel = 1;
        //public const int vbAbortRetryIgnore = 2;
        //public const int vbYesNoCancel = 3;
        //public const int vbYesNo = 4;
        //public const int vbRetryCancel = 5;
        //public const int vbCritical = 16;
        //public const int vbQuestion = 32;
        //public const int vbExclamation = 48;
        //public const int vbInformation = 64;
        //public const int vbDefaultButton1 = 0;
        //public const int vbDefaultButton2 = 256;
        //public const int vbDefaultButton3 = 512;
    }
}
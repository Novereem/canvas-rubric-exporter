using System;
using System.Runtime.InteropServices;

public static class KnownFolders
{
    private const string Shell32 = "shell32.dll";

    private static readonly Guid DownloadsFolderGuid = new Guid("374DE290-123F-4565-9164-39C4925E467B");

    [DllImport(Shell32, CharSet = CharSet.Unicode, ExactSpelling = true)]
    private static extern int SHGetKnownFolderPath(
        [MarshalAs(UnmanagedType.LPStruct)] Guid rfid,
        uint dwFlags,
        IntPtr hToken,
        out IntPtr pszPath);

    public static string GetDownloadsFolderPath()
    {
        IntPtr pszPath = IntPtr.Zero;
        try
        {
            int hr = SHGetKnownFolderPath(DownloadsFolderGuid, 0, IntPtr.Zero, out pszPath);
            if (hr >= 0)
            {
                string path = Marshal.PtrToStringUni(pszPath);
                return path;
            }
            else
            {
                throw Marshal.GetExceptionForHR(hr);
            }
        }
        finally
        {
            if (pszPath != IntPtr.Zero)
            {
                Marshal.FreeCoTaskMem(pszPath);
            }
        }
    }
}
﻿// WinEI
// https://github.com/MuertoGB/WinEI

// NativeMethods.cs
// Released under the GNU GLP v3.0

using System;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;

namespace WinEI.WIN32
{
    internal class NativeMethods
    {
        // https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-releasecapture
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        [ResourceExposure(ResourceScope.None)]
        internal static extern bool ReleaseCapture(
            HandleRef hWnd);

        // https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-sendmessage
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        [ResourceExposure(ResourceScope.None)]
        internal static extern IntPtr SendMessage(
            HandleRef hWnd,
            int Msg,
            IntPtr wParam,
            IntPtr lParam);

        // https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-addfontmemresourceex
        [DllImport("gdi32.dll", ExactSpelling = true)]
        internal static extern IntPtr AddFontMemResourceEx(
            IntPtr pFileView,
            uint cjSize,
            IntPtr pvReserved,
            [In] ref uint pNumFonts);

        // https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-setwindowshookexa
        [DllImport("user32.dll", SetLastError = true)]
        internal static extern IntPtr SetWindowsHookExA(
            int idHook,
            LowLevelKeyboardProc lpfn,
            IntPtr hMod,
            uint dwThreadId);

        // Low level keyboard hook delegate
        internal delegate IntPtr LowLevelKeyboardProc(
            int nCode,
            IntPtr wParam,
            IntPtr lParam);

        // https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-unhookwindowshookex
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool UnhookWindowsHookEx(
            IntPtr hhk);

        // https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-callnexthookex
        [DllImport("user32.dll", SetLastError = true)]
        internal static extern IntPtr CallNextHookEx(
            IntPtr hhk,
            int nCode,
            IntPtr wParam,
            IntPtr lParam);

        // https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getkeystate
        [DllImport("user32.dll", SetLastError = true)]
        internal static extern short GetKeyState(
            int nVirtKey);

        // https://learn.microsoft.com/en-us/windows/win32/api/libloaderapi/nf-libloaderapi-getmodulehandlea
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern IntPtr GetModuleHandleA(
            string lpModuleName);
    }
}
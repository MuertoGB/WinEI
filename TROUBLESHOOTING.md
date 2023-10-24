## Troubleshooting

#### Bugged WinSAT?

**Overview:**\
The operating system is using a version of WinSAT that may encounter issues while assessing the system. The error can occur during the system assessment, and the message may indicate: "Failed to properly assess the disk. The parameter is incorrect.". For more details, refer to [this article](https://support.microsoft.com/en-us/topic/-the-parameter-is-incorrect-error-message-when-you-run-winsat-in-windows-7-b8c320cc-ce3f-70a7-593e-8aa3ed3b5b5f).

**Affected Operating Systems:**
```
Windows 7 32-bit, and 64-bit.
```

**Affected WinSAT Executables:**
```
6.1.7600.16976
6.1.7600.21167
6.1.7601.17793
6.1.7601.21940
```

**Resolution**:

A hotfix is provided by Microsoft and can be downloaded from one of the following links, based on your Operating System architecture. If you're unsure about the architecture, you can check it in WinEI by opening the 'System Details' window (ALT + D) and examining the Operating System Text.

For 32-Bit Windows 7: [Windows6.1-KB2687862-x86.msu](https://github.com/MuertoGB/WinEI/raw/main/stream/hotfix/Windows6.1-KB2687862-x86.msu)\
For 64-Bit Windows 7: [Windows6.1-KB2687862-x64.msu](https://github.com/MuertoGB/WinEI/raw/main/stream/hotfix/Windows6.1-KB2687862-x64.msu)

<kbd>
	<img src="stream/images/bitness.png">
</kbd>

---
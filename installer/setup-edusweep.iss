#define MyAppName "EduSweep"
#define MyAppVersion "2.6.0"
#define MyAppPublisher "Paul Beesley"
#define MyAppURL "https://github.com/paulbeesley3/EduSweep"
#define CoreAppName "EduSweep.exe"
#define InspectorAppName "finspector.exe"

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{E1D73445-9DBE-42FB-921B-BF68487363FC}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={pf}\{#MyAppName}
DefaultGroupName={#MyAppName}
AllowNoIcons=yes
LicenseFile=..\LICENSE.txt
OutputDir=.\output
OutputBaseFilename=EduSweep Installer
SetupIconFile=..\static_resource\edusweep2.ico
Compression=lzma
SolidCompression=yes

; Windows 7 / Server 2008 R2
MinVersion=6.1.7600

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Types]
Name: "full"; Description: "Full installation"
Name: "compact"; Description: "Minimal installation"
Name: "custom"; Description: "Custom installation"; Flags: iscustom

[Components]
Name: "core"; Description: "Core Application"; Types: full compact custom; Flags: fixed
Name: "insp"; Description: "File Inspector Tool"; Types: full custom
Name: "sig"; Description: "Default Signatures"; Types: full compact custom

[Dirs]
Name: "{app}\Signatures"

[Files]
; Core Application Component (core)
Source: "..\EduSweep 2\bin\Release\EduSweep.exe"; DestDir: "{app}"; Flags: ignoreversion; Components: core
Source: "..\EduSweep 2\bin\Release\Castle.Core.dll"; DestDir: "{app}"; Flags: ignoreversion; Components: core
Source: "..\EduSweep 2\bin\Release\Config.Net.dll"; DestDir: "{app}"; Flags: ignoreversion; Components: core
Source: "..\EduSweep 2\bin\Release\Config.Net.Json.dll"; DestDir: "{app}"; Flags: ignoreversion; Components: core
Source: "..\EduSweep 2\bin\Release\Crc32.NET.dll"; DestDir: "{app}"; Flags: ignoreversion; Components: core
Source: "..\EduSweep 2\bin\Release\EduEngine.dll"; DestDir: "{app}"; Flags: ignoreversion; Components: core
Source: "..\EduSweep 2\bin\Release\EdUtils.dll"; DestDir: "{app}"; Flags: ignoreversion; Components: core
Source: "..\EduSweep 2\bin\Release\Microsoft.WindowsAPICodePack.dll"; DestDir: "{app}"; Flags: ignoreversion; Components: core
Source: "..\EduSweep 2\bin\Release\Microsoft.WindowsAPICodePack.Shell.dll"; DestDir: "{app}"; Flags: ignoreversion; Components: core
Source: "..\EduSweep 2\bin\Release\nClam.dll"; DestDir: "{app}"; Flags: ignoreversion; Components: core
Source: "..\EduSweep 2\bin\Release\Newtonsoft.Json.dll"; DestDir: "{app}"; Flags: ignoreversion; Components: core
Source: "..\EduSweep 2\bin\Release\NLog.dll"; DestDir: "{app}"; Flags: ignoreversion; Components: core
Source: "..\EduSweep 2\bin\Release\NLog.Windows.Forms.dll"; DestDir: "{app}"; Flags: ignoreversion; Components: core

; File Inspector Component (insp)
Source: "..\File Inspector\bin\Release\finspector.exe"; DestDir: "{app}"; Flags: ignoreversion; Components: insp

; Default Signatures Component (sig)
Source: "..\static_resource\signatures\*"; DestDir: "{app}\Signatures"; Flags: ignoreversion recursesubdirs createallsubdirs; Components: sig

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#CoreAppName}"
Name: "{group}\File Inspector"; Filename: "{app}\{#InspectorAppName}"; Flags: createonlyiffileexists
Name: "{group}\{cm:UninstallProgram,{#MyAppName}}"; Filename: "{uninstallexe}"
Name: "{commondesktop}\{#MyAppName}"; Filename: "{app}\{#CoreAppName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#CoreAppName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

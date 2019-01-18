#define MyAppName "EduSweep"
#define MyAppVersion "2.6.0"
#define MyAppPublisher "Paul Beesley"
#define MyAppURL "https://github.com/paulbeesley3/EduSweep"
#define CoreAppName "EduSweep.exe"
#define InspectorAppName "finspector.exe"
#define StudioAppName "sigstudio.exe"

[Setup]
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

; Only add install references if not in portable mode
Uninstallable=not IsTaskSelected('portable')

; Windows 7 / Server 2008 R2
MinVersion=6.1.7600

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked exclusive
Name: "portable"; Description: "Make installation portable"; Flags: unchecked exclusive

[Types]
Name: "full"; Description: "Full installation"
Name: "compact"; Description: "Minimal installation"
Name: "custom"; Description: "Custom installation"; Flags: iscustom

[Components]
Name: "core"; Description: "Core Application"; Types: full compact custom; Flags: fixed
Name: "sig"; Description: "Default Signatures"; Types: full compact custom; Flags: fixed
Name: "insp"; Description: "File Inspector Tool"; Types: full custom
Name: "studio"; Description: "Signature Studio Tool"; Types: full custom

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
Source: "..\EduSweep 2\bin\Release\ObjectListView.dll"; DestDir: "{app}"; Flags: ignoreversion; Components: core
Source: "..\EduSweep 2\bin\Release\System.ValueTuple.dll"; DestDir: "{app}"; Flags: ignoreversion; Components: core

; File Inspector Component (insp)
Source: "..\File Inspector\bin\Release\finspector.exe"; DestDir: "{app}"; Flags: ignoreversion; Components: insp
Source: "..\lib\trid\TrIDLib-License.txt"; DestDir: "{app}"; Flags: ignoreversion; Components: insp
Source: "..\static_resource\trid\triddefs.trd"; DestDir: "{app}"; Flags: ignoreversion; Components: insp

; Default Signatures Component (sig)
Source: "..\static_resource\signatures\*"; DestDir: "{app}\Signatures"; Flags: ignoreversion recursesubdirs createallsubdirs; Components: sig

; Signature Studio Component (studio)
Source: "..\Signature Studio\bin\Release\sigstudio.exe"; DestDir: "{app}"; Flags: ignoreversion; Components: studio

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#CoreAppName}"; Tasks: not portable
Name: "{group}\File Inspector"; Filename: "{app}\{#InspectorAppName}"; Flags: createonlyiffileexists; Tasks: not portable
Name: "{group}\Signature Studio"; Filename: "{app}\{#StudioAppName}"; Flags: createonlyiffileexists; Tasks: not portable
Name: "{group}\{cm:UninstallProgram,{#MyAppName}}"; Filename: "{uninstallexe}"; Tasks: not portable
Name: "{commondesktop}\{#MyAppName}"; Filename: "{app}\{#CoreAppName}"; Tasks: desktopicon; Tasks: not portable

[Run]
Filename: "{app}\{#CoreAppName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

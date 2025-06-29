[Setup]
AppName=Medical Soft
AppVersion=1.0
DefaultDirName={pf}\Medical-Soft
DefaultGroupName=Medical Soft
OutputDir=Output
OutputBaseFilename=MedicalSoftInstaller
Compression=lzma
SolidCompression=yes
ArchitecturesInstallIn64BitMode=x64

[Files]
Source: ".\docker-compose.yml"; DestDir: "{app}"
Source: "..\InstallerSource\nginx.conf"; DestDir: "{app}"
Source: ".\start.bat"; DestDir: "{app}"
Source: ".\down.bat"; DestDir: "{app}"
Source: ".\doctor.ico"; DestDir: "{app}"

[Code]
function DockerIsInstalled(): Boolean;
var
  ResultCode: Integer;
begin
  Result := Exec('cmd.exe', '/C docker --version', '', SW_HIDE, ewWaitUntilTerminated, ResultCode);
end;

procedure InitializeWizard;
begin
  if not DockerIsInstalled() then
  begin
    MsgBox('Docker no está instalado o no está en el PATH del sistema. Por favor instálalo antes de continuar.', mbCriticalError, MB_OK);
    WizardForm.Close;
    Exit;
  end;
end;

procedure CurStepChanged(CurStep: TSetupStep);
var
  EnvFile: string;
  EnvText: AnsiString;
  ResultCode: Integer;
begin
  if CurStep = ssPostInstall then
  begin
    EnvText :=
      'SA_PASSWORD=Cbmwjmkq23$' + #13#10;

    EnvFile := ExpandConstant('{app}\.env');
    SaveStringToFile(EnvFile, EnvText, False);

    Exec('cmd.exe', '/C docker-compose up -d --build', ExpandConstant('{app}'), SW_SHOW, ewWaitUntilTerminated, ResultCode);
  end;
end;

function GetAppUrl(Param: string): string;
begin
  Result := 'http://localhost/';
end;

[Tasks]
Name: "desktopicon"; Description: "Crear acceso directo en el escritorio"; GroupDescription: "Accesos directos adicionales:"

[Icons]
Name: "{group}\Medical Office"; Filename: "{code:GetAppUrl}"; IconFilename: "{app}\doctor.ico"
Name: "{commondesktop}\Medical Office"; Filename: "{code:GetAppUrl}"; Tasks: desktopicon; IconFilename: "{app}\doctor.ico"

[UninstallRun]
Filename: "{app}\down.bat"; Flags: runhidden

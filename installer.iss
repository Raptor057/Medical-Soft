[Setup]
AppName=Medical Office
AppVersion=1.0
DefaultDirName={pf}\MedicalOffice
DefaultGroupName=Medical Office
OutputBaseFilename=MedicalOfficeInstaller
Compression=lzma
SolidCompression=yes

[Files]
Source: ".\InstallerSource\Medical.Office.Net8WebApi\*"; \
  DestDir: "{app}\Medical.Office.Net8WebApi"; \
  Flags: recursesubdirs; \
  Excludes: "bin\*;obj\*;.vs\*;*.user;*.suo;*.log;*.tmp"

Source: ".\InstallerSource\Medical.Office.ReactWebClient\*"; \
  DestDir: "{app}\Medical.Office.ReactWebClient"; \
  Flags: recursesubdirs; \
  Excludes: "node_modules\*;dist\*;*.log;*.tmp"

Source: ".\InstallerSource\Medical.Office.SqlLocalDB\*"; \
  DestDir: "{app}\Medical.Office.SqlLocalDB"; \
  Flags: recursesubdirs; \
  Excludes: "bin\*;obj\*;.vs\*;*.user;*.suo;*.log;*.tmp"

Source: ".\InstallerSource\docker-compose.yml"; DestDir: "{app}"
Source: ".\start.bat"; DestDir: "{app}"

[Code]
var
  ConfigPage: TInputQueryWizardPage;
  SA_Password, ServerIP, API_URL: string;

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

  ConfigPage := CreateInputQueryPage(wpWelcome, 'Configuración del sistema',
    'Parámetros de entorno',
    'Por favor introduce la IP del servidor donde se desplegará el API:');

  ConfigPage.Add('IP del servidor (ej: 192.168.0.100):', False);
end;

procedure CurStepChanged(CurStep: TSetupStep);
var
  EnvFile: string;
  EnvText: AnsiString;
  ResultCode: Integer;
begin
  if CurStep = ssPostInstall then
  begin
    SA_Password := 'Cbmwjmkq23$';
    ServerIP := ConfigPage.Values[0];
    API_URL := 'http://' + ServerIP + ':8080/';

    EnvText :=
      'SA_PASSWORD=' + SA_Password + #13#10 +
      'GPG_PASSPHRASE=VdDySlYI1XMm1YKsit6XWIfkPxClijXgOZaAt9eobNaxHX4MZh' + #13#10 +
      'NEXT_PUBLIC_API_URL=' + API_URL + #13#10;

    EnvFile := ExpandConstant('{app}\.env');
    SaveStringToFile(EnvFile, EnvText, False);

    Exec('cmd.exe', '/C docker-compose up -d', ExpandConstant('{app}'), SW_SHOW, ewWaitUntilTerminated, ResultCode);
  end;
end;

function GetAppUrl(Param: string): string;
begin
  Result := 'http://' + ConfigPage.Values[0] + ':3000/';
end;

[Tasks]
Name: "desktopicon"; Description: "Crear acceso directo en el escritorio"; GroupDescription: "Accesos directos adicionales:"

[Icons]
Name: "{group}\Abrir Medical Office"; Filename: "{code:GetAppUrl}"
Name: "{commondesktop}\Abrir Medical Office"; Filename: "{code:GetAppUrl}"; Tasks: desktopicon

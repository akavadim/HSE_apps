#include "OfficeApi.h"

void OfficeApi::RunWord() {
	UINT resCode = WinExec("C:\\Program Files\\Microsoft Office\\root\\Office16\\WINWORD.EXE", SW_SHOW);
	if (resCode < 32)
	{
		LPSTR messageBuffer = nullptr;
		FormatMessageA(FORMAT_MESSAGE_ALLOCATE_BUFFER | FORMAT_MESSAGE_FROM_SYSTEM | FORMAT_MESSAGE_IGNORE_INSERTS,
			NULL, resCode, MAKELANGID(LANG_NEUTRAL, SUBLANG_DEFAULT), (LPSTR)&messageBuffer, 0, NULL);
		throw exception(messageBuffer);
	}
}
PROCESS_INFORMATION OfficeApi::RunExcel() {
	STARTUPINFO startupInfo;
	ZeroMemory(&startupInfo, sizeof(startupInfo));
	PROCESS_INFORMATION procInfo;
	const wchar_t* path = L"C:\\Program Files\\Microsoft Office\\root\\Office16\\EXCEL.EXE";

	CreateProcess(path, NULL, NULL, FALSE, NULL, NULL, NULL, NULL, &startupInfo, &procInfo);

	return procInfo;
}

void OfficeApi::Open(const char* path) {
	int nChars = MultiByteToWideChar(CP_ACP, 0, path, -1, NULL, 0);
	const WCHAR* wPath = new WCHAR[nChars];
	MultiByteToWideChar(CP_ACP, 0, path, -1, (LPWSTR)wPath, nChars);

	auto resCode = ShellExecute(NULL, L"open", wPath, NULL, NULL, SW_SHOWNORMAL);

	if ((int)resCode <= 32)
	{
		LPSTR messageBuffer = nullptr;
		FormatMessageA(FORMAT_MESSAGE_ALLOCATE_BUFFER | FORMAT_MESSAGE_FROM_SYSTEM | FORMAT_MESSAGE_IGNORE_INSERTS, 
			NULL, (int)resCode, 0, (LPSTR)&messageBuffer, 0, NULL);
		throw exception(messageBuffer);
	}
}
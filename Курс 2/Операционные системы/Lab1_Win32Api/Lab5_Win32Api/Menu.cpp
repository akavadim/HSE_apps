#include "Menu.h"

void Menu::Show(){
	cout << "Command Mode 0.9\nEnter 'help' for info" << endl;

	char input[100];
	char tempChar[100];

	do {
		cin.getline(input, 100);

		if (strcmp(input, "help") == 0) 
			Help();
		else if (strncmp(input, "run ", 4) == 0) 
			Run(&input[4]);
		else if (strncmp(input, "open ", 5)==0)
			Open(&input[5]);
		else if (strcmp(input, "exit")!=0)
			cout << "Wrong command '"<<input <<"'. Enter 'help' for info." << endl;

	} while (strcmp(input, "exit"));
}

void Menu::Help() {

	cout << "-run [word/excel]" << endl
		<< "-open <path>" << endl
		<< "-exit" << endl;
}

void Menu::Run(const char* str) {
	if (strcmp(str, "word") == 0) {
		try {
			officeApi.RunWord();
		}
		catch (exception ex)
		{
			cout << "Error" << ex.what() << endl;
		}
	}
	else if (strcmp(str, "excel") == 0) 
	{
		auto procInfo = officeApi.RunExcel();
		TCHAR wProcName[MAX_PATH];
		DWORD exitCodeProc;

		if (!GetModuleFileNameEx(procInfo.hProcess, 0, wProcName, MAX_PATH))
			wcout << L"Error: " << GetLastErrorMessage() << endl;
		GetExitCodeProcess(procInfo.hProcess, &exitCodeProc);

		cout << "Process ID: " << procInfo.dwProcessId << endl
			<< "Process handle: " << procInfo.hProcess << endl;
		wcout << L"File name: " << wProcName << endl
			<< L"Exit code process: " << exitCodeProc << endl;
	}
	else
		cout << "Wrong command '" << str << "'. You should enter 'word' or 'excel'. Enter 'help' for info." << endl;
}

void Menu::Open(const char* str) {
	try {
		officeApi.Open(str);
	}
	catch (exception ex) {
		cout << "Error: " << ex.what()<< endl;
	}
}

LPSTR Menu::GetLastErrorMessage() {
	LPSTR messageBuffer = nullptr;
	auto errCode = GetLastError();
	FormatMessageA(FORMAT_MESSAGE_ALLOCATE_BUFFER | FORMAT_MESSAGE_FROM_SYSTEM | FORMAT_MESSAGE_IGNORE_INSERTS,
		NULL, errCode, MAKELANGID(LANG_NEUTRAL, SUBLANG_DEFAULT), (LPSTR)&messageBuffer, 0, NULL);
	return messageBuffer;
}
#pragma once
#include "OfficeApi.h"
#include <iostream>
#include <string.h>
#include <Psapi.h>

using namespace std;

class Menu
{
public:
	Menu(OfficeApi);
	void Show();

private:
	OfficeApi officeApi;
	void Help();
	void Run(const char*);
	void Open(const char*);
	LPSTR GetLastErrorMessage();
};

inline Menu::Menu(OfficeApi api)
{
	officeApi = api;
}


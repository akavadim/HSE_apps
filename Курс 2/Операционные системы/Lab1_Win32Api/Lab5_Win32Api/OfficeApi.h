#pragma once

#include "windows.h"
#include <stdio.h>
#include <iostream>

using namespace std;

class OfficeApi
{
public:
	OfficeApi();
	void RunWord();
	PROCESS_INFORMATION RunExcel();
	void Open(const char*);

private:

};

inline OfficeApi::OfficeApi()
{
}


#include "MyString.h"

bool MyString::Compare(const char* str1, const char* str2) {

	bool res = true;
	int i1, i2;

	for (i1 = 0, i2 = 0; str1[i1]!='\0' and str2[i2]!='\0'; i1++, i2++) {

		if (str1[i1] != str2[i2])
		{
			res = false;
			break;
		}
	}

	if (str1[i1] != str2[i2])
		res = false;

	return res;
}
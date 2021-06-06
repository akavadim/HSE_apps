
#include <iostream>
#include "Menu.h"

int main()
{
    OfficeApi api;
    Menu menu = Menu(api);
    menu.Show();
}

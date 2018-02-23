#include "Card.h"
using namespace CCCore;
using namespace System;

Card::Card()
{
	CardBackground^ bg = gcnew CardBackground();
	elements.Add(bg);

}


Card::~Card()
{
}

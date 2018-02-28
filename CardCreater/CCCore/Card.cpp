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

CardElement^ CCCore::Card::Get(int i)
{
	return elements[i];
}

void CCCore::Card::Set(CardElement^ ce)
{
	CardElement^ el;

	switch (ce->type)
	{
	case 0:
		el = gcnew CardBackground(*((CardBackground^)ce));
		break;
	case 1:
		el = gcnew CardFram(*((CardFram^)ce));
		break;
	case 2:
		el = gcnew CardImage(*((CardImage^)ce));
		break;
	case 3:
		el = gcnew CardImgNum(*((CardImgNum^)ce));
		break;
	case 4:
		el = gcnew CardText(*((CardText^)ce));
		break;
	default:
		el = gcnew CardElement(*((CardElement^)ce));
	}

	elements.Add(el);
	elements[elements.Count - 1]->layer = elements.Count - 1;

}

void CCCore::Card::Swap(int a, int b)
{
	if (a >= elements.Count || b >= elements.Count)
		return;

	elements[a]->layer = b;
	elements[b]->layer = a;

	CardElement^ temp;
	
	temp = elements[a];
	elements[a] = elements[b];
	elements[b] = temp;
}

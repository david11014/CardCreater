#pragma once
#include "Cardelement.h"
using namespace System;
using namespace System::Collections::Generic;

namespace CCCore
{
	public ref class Card
	{

	public:
		
		Card();
		~Card();
		int width, height;
		CardElement^ Get(int i);
		void Set(CardElement^ ce);
		void Set(int i, CardElement^ ce);
		void RemoveElements(int i);
		void Swap(int a, int b);
		int ElementCount();
	private:
		List<CardElement^> elements;
	};
		
}



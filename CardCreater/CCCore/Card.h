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
		
		List<CardElement^> elements;


		CardElement^ Get(int i);
		void Set(CardElement^ ce);		
	};
		
}



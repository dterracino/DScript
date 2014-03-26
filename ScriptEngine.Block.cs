﻿/*
Copyright (c) 2014 Darren Horrocks

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/
using System;

namespace DScript
{
	public partial class ScriptEngine
	{
		private void Block(bool execute)
		{
			_currentLexer.Match((ScriptLex.LexTypes)'{');
			if (execute)
			{
				while (_currentLexer.TokenType != 0 && _currentLexer.TokenType != (ScriptLex.LexTypes)'}')
				{
					Statement(execute);
					_currentLexer.Match((ScriptLex.LexTypes)'}');
				}
			}
			else
			{
				Int32 brackets = 1;
				while (_currentLexer.TokenType != 0 && brackets > 0)
				{
					if (_currentLexer.TokenType == (ScriptLex.LexTypes)'{')
					{
						brackets++;
					}
					if (_currentLexer.TokenType == (ScriptLex.LexTypes)'}')
					{
						brackets--;
					}

					_currentLexer.Match(_currentLexer.TokenType);
				}
			}
		}
	}
}
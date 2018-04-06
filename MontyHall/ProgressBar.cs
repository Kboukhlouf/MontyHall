using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MontyHall
{
	public class ProgressBar
	{
		private long _progress = 0;
		private double _previousProgressPercent = 0.00d;
		private double _progressPercent = 0.00d;
		private long _overall = 0;

		public ProgressBar(long overall)
		{
			_overall = overall;
		}

		public void Increment()
		{
			++_progress;
			CalculatProgressPercent();
		}

		public void IncrementAndDisplay()
		{
			Display();
			Increment();
			Display();
		}

		private void CalculatProgressPercent()
		{
			_progressPercent = (double)_progress / _overall * 100;
		}

		public void Display()
		{
			if (_progress == 0) Console.Write("[");
			if (_progress == _overall) Console.WriteLine("]");
			if ((_progressPercent - _previousProgressPercent) > 1.00d)
			{
				Console.Write("|");
				_previousProgressPercent = _progressPercent;
			}
		}

	}
}

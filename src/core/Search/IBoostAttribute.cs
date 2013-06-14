﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lucene.Net.Util;
using Lucene.Net.Index;

namespace Lucene.Net.Search
{
	public interface IBoostAttribute : Attribute
	{
		void SetBoost(float boost);
		float GetBoost();
	}
}

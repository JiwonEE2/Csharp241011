using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp241011
{
	public enum ItemType
	{
		Weapon, Armor, Potion, Helmet
	}
	class Item
	{
		public string name { get; set; }
		public ItemType Type { get; set; }
	}
	class Player
	{
		private Dictionary<ItemType, Item> items = new Dictionary<ItemType, Item>();
		public string name { get; set; }
		public Player(string name)
		{
			this.name = name;
		}
		public void EquipItem(Item item)
		{
			// 동일 타입의 아이템이 이미 장착되어 있으면
			if (items.ContainsKey(item.Type)) { }
		}
	}
	internal class Collection
	{
		/*
		[ Collection ]
		- 같은 성격을 띄는 데이터에 모음을 저장하고 관리하는 자료구조
		- 데이터 그룹화
		- 저장, 검색, 수정, 삭제를 효율적으로 처리하기 위해

		[ Non-Generic Collection ]
		- ArrayList, Hashtable, SortedList, ...

		[ Generic Collection ]
		- List, Dictionary, Queue, Stack
		*/
		static void Main()
		{
			List<int> number = new List<int> { 1, 2, 3, 4 };

			List<Item> items = new List<Item>();
		}
	}
}
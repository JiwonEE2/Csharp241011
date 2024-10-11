/*
[ 실습 ]
1. 리스트 활용
- 캐릭터 클래스 생성
- 리스트로 관리
- 캐릭터 추가, 삭제, 검색

2. 딕셔너리 활용
- 아이템 클래스
- 아이템 추가, 삭제, 검색

3. 캐릭터 + 아이템
- 탈착 시스템 -> 능력치 변경
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp241011
{
	class Player
	{
		public string Name { get; set; }
		public int Att { get; set; }
		public int Def { get; set; }
		public Item EquippedItem { get; set; }
		public Player(string name, int att, int def)
		{
			Name = name;
			Att = att;
			Def = def;
			EquippedItem = null;
		}
		public void EquipItem(Item equippedItem)
		{
			Att += equippedItem.Att;
			Def += equippedItem.Def;
			EquippedItem = equippedItem;
		}
		public void UnEquipItem(Item equippedItem)
		{
			Att -= equippedItem.Att;
			Def -= equippedItem.Def;
			EquippedItem = null;
		}
		public override string ToString()
		{
			return $"이름 : {Name}\t공격력 : {Att}\t방어력 : {Def}\n장착한 아이템 ->\t{EquippedItem}";
		}
	}
	class Item
	{
		public string Name { get; set; }
		public int Att { get; set; }
		public int Def { get; set; }
		public Item(string name, int att, int def)
		{
			Name = name;
			Att = att;
			Def = def;
		}
		public override string ToString()
		{
			return $"이름 : {Name}\t공격력 : {Att}\t방어력 : {Def}";
		}
	}
	internal class Exercise
	{
		static void Main()
		{
			List<Player> players = new List<Player>();
			Dictionary<string, Item> items = new Dictionary<string, Item>();
			int input;
			string name;
			int att;
			int def;
			string iName;
			while (true)
			{
				Console.WriteLine("=======================================================");
				Console.WriteLine("[ 플레이어 리스트 ]");
				if (players.Count == 0)
				{
					Console.WriteLine("비어있음");
				}
				else
				{
					foreach (var player in players)
					{
						Console.WriteLine(player);
					}
				}
				Console.WriteLine();
				Console.WriteLine("-------------------------------------------------------");
				Console.WriteLine("[ 아이템 리스트 ]");
				if (items.Count == 0)
				{
					Console.WriteLine("비어있음");
				}
				else
				{
					foreach (var item in items)
					{
						Console.WriteLine(item.Value);
					}
				}
				Console.WriteLine();
				Console.WriteLine("-------------------------------------------------------");
				Console.WriteLine("1. 플레이어 생성");
				Console.WriteLine("2. 플레이어 삭제");
				Console.WriteLine("3. 아이템 생성");
				Console.WriteLine("4. 아이템 삭제");
				Console.WriteLine("5. 아이템 장착");
				Console.WriteLine("6. 아이템 탈착");
				input = int.Parse(Console.ReadLine());
				switch (input)
				{
					case 1:
						Console.Write("생성할 플레이어 이름 : ");
						name = Console.ReadLine();
						if (players.Exists(x => x.Name == name))    // 람다식 사용 방법 1
						{
							Console.Clear();
							Console.WriteLine("이미 존재하는 이름입니다.");
						}
						else
						{
							Console.Write("플레이어 공격력 : ");
							att = int.Parse(Console.ReadLine());
							Console.Write("플레이어 방어력 : ");
							def = int.Parse(Console.ReadLine());
							players.Add(new Player(name, att, def));
							Console.Clear();
							Console.WriteLine($"{name}의 플레이어가 생성되었습니다.");
						}
						break;
					case 2:
						if (players.Count() == 0)
						{
							Console.Clear();
							Console.WriteLine("플레이어가 하나도 없습니다.");
						}
						else
						{
							Console.Write("삭제할 플레이어 이름 : ");
							name = Console.ReadLine();
							if (players.Exists(x => x.Name.Contains(name))) // 람다식 사용 방법 2
							{
								players.Remove(players.Find(x => x.Name.Contains(name)));
								Console.Clear();
								Console.WriteLine($"{name}의 이름을 가진 플레이어를 삭제하였습니다.");
							}
							else
							{
								Console.Clear();
								Console.WriteLine($"{name}의 이름을 가진 플레이어가 존재하지 않습니다.");
							}
						}
						break;
					case 3:
						Console.Write("생성할 아이템 이름 : ");
						name = Console.ReadLine();
						// 아이템 이름이 이미 존재하는 경우
						if (items.ContainsKey(name))
						{
							Console.Clear();
							Console.WriteLine("이미 존재하는 이름입니다.");
						}
						else
						{
							Console.Write("아이템 공격력 : ");
							att = int.Parse(Console.ReadLine());
							Console.Write("아이템 방어력 : ");
							def = int.Parse(Console.ReadLine());
							items.Add(name, new Item(name, att, def));
							Console.Clear();
							Console.WriteLine($"{name}의 아이템이 생성되었습니다.");
						}
						break;
					case 4:
						if (items.Count() == 0)
						{
							Console.Clear();
							Console.WriteLine("아이템이 하나도 없습니다.");
						}
						else
						{
							Console.Write("삭제할 아이템 이름 : ");
							iName = Console.ReadLine();
							if (items.ContainsKey(iName))
							{
								// 장착한 플레이어가 없을 시에만 아이템 삭제 가능하게
								if (players.Exists(x => x.EquippedItem == items[iName]))
								{
									Console.Clear();
									Console.WriteLine($"{iName}의 아이템을 장착중인 플레이어가 있습니다. 탈착 후 아이템을 삭제해주세요.");
								}
								else
								{
									items.Remove(iName);
									Console.Clear();
									Console.WriteLine($"{iName}의 이름을 가진 아이템을 삭제했습니다.");
								}
							}
							else
							{
								Console.Clear();
								Console.WriteLine($"{iName}의 이름을 가진 아이템이 존재하지 않습니다.");
							}
						}
						break;
					case 5:
						Console.Write("아이템을 장착할 플레이어의 이름 : ");
						name = Console.ReadLine();
						if (players.Exists(x => x.Name == name))
						{
							Console.Write("장착할 아이템의 이름 : ");
							iName = Console.ReadLine();
							if (items.ContainsKey(iName))
							{
								Console.Clear();
								Console.WriteLine($"{iName}을 장착하였습니다.");
								// 아이템 장착
								players.Find(x => x.Name == name).EquipItem(items[iName]);
							}
							else
							{
								Console.Clear();
								Console.WriteLine("해당 아이템이 존재하지 않습니다.");
							}
						}
						else
						{
							Console.Clear();
							Console.WriteLine("해당 플레이어가 존재하지 않습니다.");
						}
						break;
					case 6:
						Console.Write("아이템을 탈착할 플레이어의 이름 : ");
						name = Console.ReadLine();
						if (players.Exists(x => x.Name == name))
						{
							if (players.Find(x => x.Name == name).EquippedItem == null)
							{
								Console.Clear();
								Console.WriteLine("해당 플레이어는 아이템을 장착하고 있지 않습니다.");
							}
							else
							{
								Console.WriteLine("탈착할 아이템의 이름 : ");
								iName = Console.ReadLine();
								if (items.ContainsKey(iName))
								{
									Console.Clear();
									Console.WriteLine($"{iName}을 탈착하였습니다.");
									// 아이템 탈착
									players.Find(x => x.Name == name).UnEquipItem(items[iName]);
								}
								else
								{
									Console.Clear();
									Console.WriteLine("해당 아이템이 존재하지 않습니다.");
								}
							}
						}
						else
						{
							Console.Clear();
							Console.WriteLine("해당 플레이어가 존재하지 않습니다.");
						}
						break;
				}
			}
		}
	}
}
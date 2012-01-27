using System;
using IndivoClient;

namespace EsomaSharedDocuments
{
	[Serializable]
	public class IndivoExercisePlan
	{
		public ExercisePlan Plan { get; set; }
		public string AccountID { get; set; }
		public int Age { get; set; }
		public string Gender { get; set; }
		
		public IndivoExercisePlan()
		{
		}
		
		public IndivoExercisePlan(string jsonString)
		{
			if (!String.IsNullOrEmpty(jsonString))
			{
				Console.WriteLine(jsonString);
				IndivoExercisePlan temp = JSONSerializationHelper.DeserializeString<IndivoExercisePlan>(jsonString);
				
				if (temp != null)
					HydrateObject(temp.Plan, temp.AccountID, temp.Age, temp.Gender);
				else
					Console.WriteLine("deserialization failed");
			}
			else
			{
				Console.WriteLine("string was null or empty");
			}
		}
		
		public IndivoExercisePlan(ExercisePlan plan, string accountId, int userAge, string userGender)
		{
			HydrateObject(plan, accountId, userAge, userGender);
		}
		
		private void HydrateObject(ExercisePlan plan, string accountId, int age, string gender)
		{
			this.Plan = plan;
			this.AccountID = accountId;
			this.Age = age;
			this.Gender = gender;
		}

		public override string ToString ()
		{
			return JSONSerializationHelper.SerializeObject<IndivoExercisePlan>(this);
		}
		
		public IndivoExercisePlan GetTodaysExercisePlan()
		{
			IndivoExercisePlan todaysPlan = new IndivoExercisePlan();
			
			if (this.Plan != null)
			{
				todaysPlan.Age = this.Age;
				todaysPlan.AccountID = this.AccountID;
				todaysPlan.Gender = this.Gender;
				
				foreach (ExercisePlanExerciseGroup exGroup in this.Plan.exerciseGroups)
				{
					if (String.IsNullOrEmpty(exGroup.daysOfWeek) || GroupOccursToday(exGroup.daysOfWeek))
					{
						todaysPlan.Plan = new ExercisePlan();
						todaysPlan.Plan.exerciseGroups.Add(exGroup);
					}
				}
			}
			
			return todaysPlan;
		}
		
		private bool GroupOccursToday(string daysOfWeek)
		{
			DayOfWeek currentDayOfWeek = DateTime.Now.DayOfWeek;
			
			int day = 0;
			
			switch (currentDayOfWeek)
			{
				case DayOfWeek.Sunday:
					day = 1;
					break;
				case DayOfWeek.Monday:
					day = 2;
					break;
				case DayOfWeek.Tuesday:
					day = 3;
					break;
				case DayOfWeek.Wednesday:
					day = 4;
					break;
				case DayOfWeek.Thursday:
					day = 5;
					break;
				case DayOfWeek.Friday:
					day = 6;
					break;
				case DayOfWeek.Saturday:
					day = 7;
					break;
			}
			
			return (daysOfWeek.Contains(day.ToString()));
		}
	}
}


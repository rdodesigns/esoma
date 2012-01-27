using System;
using System.Collections.Generic;
using IndivoClient;
using System.Configuration;

namespace CardiacRehabIndivoClient
{
	public class DataRequestor
	{
		public string AccountID { get; set; }
		public string RecordID { get; set; }
		
		private IndivoConsumer _indivoClient = null;

		string _consumerKey = "chrome";
		string _consumerSecret = "chrome_secret65238";
		string _baseUrl = "http://184.106.136.151:8000";

		public string Login(string userName, string password)
		{
			_indivoClient = new IndivoConsumer(_consumerKey, _consumerSecret, _baseUrl);
			
			String accountId = null;
			
			accountId = _indivoClient.OAuthInternalSessionCreatePost(
			                                            userName,
			                                            password,
				                                        new KeyValuePair<string, object>());
			
			this.AccountID = accountId;
			return accountId;
		}
		
		public ExercisePlan GetExercisePlan(string accountId)
		{
			ExercisePlan plan = new ExercisePlan();
			
			//using this to dummy up exercise plans
			int groupNo = new Random().Next(0, 1);
			ExercisePlanExerciseGroup exerciseGroup = GetExerciseGroup(groupNo);

			plan.exerciseGroups.Add(exerciseGroup);
			
			ExercisePlanExerciseGroup exGroup2 = new ExercisePlanExerciseGroup();
			plan.exerciseGroups.Add(exGroup2);
			
			return plan;
		}
		
		private ExercisePlanExerciseGroup GetExerciseGroup(int groupNumber)
		{
			ExercisePlanExerciseGroup exerciseGroup = new ExercisePlanExerciseGroup();
			
			// the if is to dummy up different exercise plans
			if (groupNumber == 0)
			{
				exerciseGroup.exercises = new List<ExercisePlanExerciseGroupExercise>();
	
				ExercisePlanExerciseGroupExercise exercise = new ExercisePlanExerciseGroupExercise();
				
				exercise.repititions = new ExercisePlanExerciseGroupExerciseRepititions();
				exercise.repititions.minimumValue = 5;
				exercise.repititions.maximumValue = 10;
				
				exercise.sets = new ExercisePlanExerciseGroupExerciseSets();
				exercise.sets.minimumValue = 2;
				exercise.sets.maximumValue = 4;
				
				exercise.resistance = new ExercisePlanExerciseGroupExerciseResistance();
				exercise.resistance.minimumValue = 5;
				exercise.resistance.maximumValue = 10;
				exercise.resistance.unitOfMeasurement = "Pounds";
				
				ExercisePlanExerciseGroupExerciseActivity activity = new ExercisePlanExerciseGroupExerciseActivity()
				{
					name = "Waist Bend",
					id = "1",
					type = "Conditioning",
				};
				
				exercise.activity = activity;
				exerciseGroup.exercises.Add(exercise);
				
				ExercisePlanExerciseGroupExercise exercise3 = new ExercisePlanExerciseGroupExercise();
				
				exercise3.repititions = new ExercisePlanExerciseGroupExerciseRepititions();
				exercise3.repititions.minimumValue = 4;
				exercise3.repititions.maximumValue = 8;
				
				exercise3.sets = new ExercisePlanExerciseGroupExerciseSets();
				exercise3.sets.minimumValue = 2;
				exercise3.sets.maximumValue = 4;
				
				exercise3.resistance = new ExercisePlanExerciseGroupExerciseResistance();
				exercise3.resistance.minimumValue = 0;
				exercise3.resistance.maximumValue = 5;
				exercise3.resistance.unitOfMeasurement = "Kilograms";
				
				ExercisePlanExerciseGroupExerciseActivity activity3 = new ExercisePlanExerciseGroupExerciseActivity()
				{
					name = "Lift Arms",
					id = "3",
					type = "Conditioning",
				};
				
				exercise3.activity = activity3;
				exerciseGroup.exercises.Add(exercise3);
			}
			else
			{
				ExercisePlanExerciseGroupExercise exercise2 = new ExercisePlanExerciseGroupExercise();
				exercise2.activity = new ExercisePlanExerciseGroupExerciseActivity()
				{
					id = "2",
					name = "Arm Circles",
					type = "Conditioning",
				};
				
				exercise2.sets.minimumValue = 1;
				exercise2.sets.maximumValue = 3;
				
				exercise2.repititions.minimumValue = 5;
				exercise2.repititions.maximumValue = 8;
				
				exerciseGroup.exercises.Add(exercise2);

				ExercisePlanExerciseGroupExercise exercise4 = new ExercisePlanExerciseGroupExercise();
				exercise4.activity = new ExercisePlanExerciseGroupExerciseActivity()
				{
					id = "4",
					name = "Lift Arms (Lateral)",
					type = "Conditioning",
				};
				
				exercise4.sets.minimumValue = 1;
				exercise4.sets.maximumValue = 3;
				
				exercise4.repititions.minimumValue = 7;
				exercise4.repititions.maximumValue = 10;
				
				exerciseGroup.exercises.Add(exercise4);
			}
			
			return exerciseGroup;
		}
		
		public Demographics GetDemographics(string accountId)
		{
			Demographics demo = null;
			
			if (!String.IsNullOrEmpty(accountId) || !String.IsNullOrEmpty(this.AccountID))
			{
				string records = string.Empty;
				
				try
				{
					records = _indivoClient.Accounts_X_RecordsGet(accountId, null, new KeyValuePair<string, object>());
				}
				catch {}
				
				if (!String.IsNullOrEmpty(records))
				{
					List<Record> recordList = SerializationHelper.DeserializeObject<List<Record>>(records);
					
					if (recordList != null)
					{
						foreach (Record record in recordList)
						{
							// do something
							string demoId = record.demographics.document_id;
							
							if (!String.IsNullOrEmpty(demoId))
							{
								string demographicResult = _indivoClient.Records_X_Documents_X_Get(record.id, demoId, new KeyValuePair<string, object>());
								demo = SerializationHelper.DeserializeObject<Demographics>(demographicResult);
								
								break;
							}
						}
					}
				}
			}
			
			//if demographic data can't be retrieved, dummy up some data for the prototype
			if (demo == null)
			{
				demo = new Demographics();
				demo.dateOfBirth = new DateTime(1953, 7, 24);
				demo.gender = "Female";
				
				if (!String.IsNullOrEmpty(ConfigurationManager.AppSettings["avatarGender"]))
					demo.gender = ConfigurationManager.AppSettings["avatarGender"];
			}
			
			Console.WriteLine(demo.dateOfBirth.ToString());
			return demo;
		}
	}
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace UsecaseTesting
{
    public class ActivityEntry
    {
        public Type ActivityType;
        public object ActivityData;
        public bool AssertThis;
    }

    public class UsecaseTest
    {
        public LogFactory Log_Factory { get; set; }

        public Setting TestSetting { get; private set; }

        public UsecaseTest(Setting testEnvironment, LogFactory logFactory)
        {
            
            this.TestSetting = testEnvironment;
            this.Log_Factory = logFactory;
            this.TestSetting.SetFlow(this);
        }

        public UsecaseTest(Setting testEnvironment)
        {
            this.Log_Factory = new XmlFactory(string.Empty);
            this.TestSetting = testEnvironment;
            this.TestSetting.SetFlow(this);
        }
        
        public UsecaseTest()
        {
            this.Log_Factory = new XmlFactory(string.Empty);
            this.TestSetting = new Setting();
        }

        public string TestresultPath { get; set; }
        public string DeploymentPath { get; set; }

        public int TestcaseId { get; set; }
        public string TestcaseTitle { get; set; }

        private Usecase_Activity_BeginFlow_FluentInterface _flow;
        public Usecase_Activity_BeginFlow_FluentInterface Flow
        {
            get 
            {
                if (_flow == null)
                    _flow = new Usecase_Activity_BeginFlow_FluentInterface(this);

                return _flow; 
            }
        }

        public List<ActivityEntry> ActivityEntries = new List<ActivityEntry>();

        public void RunUsecase()
        {
            Core_Log coreLog = Log_Factory.GetCoreLog();

            this.TestSetting.Initialize();

            foreach (ActivityEntry activityEntry in ActivityEntries)
            {
                var activity = (Activity)Activator.CreateInstance(activityEntry.ActivityType);
                activity.TestSetting = this.TestSetting;
                activity.Log = Log_Factory.GetActivityLog();
                if (Activity_Has_DataProperty(activityEntry.ActivityType))
                {
                    PropertyInfo prop = activityEntry.ActivityType.GetProperty("Data", BindingFlags.Public | BindingFlags.Instance);
                    
                    if (activityEntry.ActivityData == null)
                    {
                        string message = "Action: " + activityEntry.ActivityType.FullName + " needs Data of Type: " + prop.PropertyType.FullName;
                        coreLog.Write.Error(message);
                        
                        throw new ArgumentException(message);
                    }
                    
                    prop.SetValue(activity, activityEntry.ActivityData, null);
                }
                
                if (activity.Precheck() == false)
                {
                    coreLog.Write.Error("precheck failed");
                    break;
                }

                activity.DoActivity();

                if (activity.Postcheck() == false)
                { 
                    coreLog.Write.Error("postcheck failed");
                    break;
                }

                if (activityEntry.AssertThis)
                {
                    Activity_Assertion_Log assertion_log = Log_Factory.GetAssertionLog();

                    Assertion assertion = new Assertion();
                    assertion.AssertState = AssertionState.Pass;
                    assertion.Message = string.Empty;

                    activity.Assert(assertion);

                    if (assertion.AssertState == AssertionState.Fail)
                    {
                        assertion_log.Write.Fail(assertion.Message);
                        throw new UsecaseAssertFailedException(assertion.Message, activityEntry.ActivityType.FullName.ToString());
                    }

                    if (assertion.AssertState == AssertionState.Inconclusive)
                    {
                        assertion_log.Write.Inconclusive(assertion.Message);
                    }

                    if (assertion.AssertState == AssertionState.Pass)
                    {
                        assertion_log.Write.Pass(assertion.Message);
                    }
                }
            }

            this.TestSetting.Cleanup();
        }

        private bool Activity_Has_DataProperty(Type activityType)
        {
            return (activityType.GetProperties().Where<PropertyInfo>(x => x.Name == "Data").FirstOrDefault() != null);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsecaseTesting
{
    public class Usecase_Activity_FluentInterface
    {
        protected readonly UsecaseTest _usecasetest;
        public Usecase_Activity_FluentInterface(UsecaseTest usecaseTest)
        {
            _usecasetest = usecaseTest;
        }


        public Usecase_Activity_Then_FluentInterface AndAssert()
        {
            _usecasetest.ActivityEntries.Last().AssertThis = true;

            return new Usecase_Activity_Then_FluentInterface(_usecasetest);
        }

    }

    public class Usecase_Activity_BeginFlow_FluentInterface : Usecase_Activity_FluentInterface
    {
        public Usecase_Activity_BeginFlow_FluentInterface(UsecaseTest usecaseTest)
            : base(usecaseTest)
        {

        }

        public Usecase_Activity_Then_FluentInterface StartWith<T>(object activityData = null) where T : Activity
        {
            ActivityEntry activityEntry = new ActivityEntry();
            activityEntry.ActivityData = activityData;
            activityEntry.ActivityType = typeof(T);

            _usecasetest.ActivityEntries.Add(activityEntry);

            return new Usecase_Activity_Then_FluentInterface(_usecasetest);
        }


    }

    public class Usecase_Activity_Then_FluentInterface : Usecase_Activity_FluentInterface
    {
        public Usecase_Activity_Then_FluentInterface(UsecaseTest usecaseTest)
            : base(usecaseTest)
        {

        }

        public Usecase_Activity_Then_FluentInterface Then<T>(object activityData = null) where T : Activity
        {
            ActivityEntry activityEntry = new ActivityEntry();
            activityEntry.ActivityData = activityData;
            activityEntry.ActivityType = typeof(T);

            _usecasetest.ActivityEntries.Add(activityEntry);

            return new Usecase_Activity_Then_FluentInterface(_usecasetest);
        }

    }
}

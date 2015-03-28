using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsecaseTesting
{
    public abstract class Activity<Activity_Data> : Activity
    {
        public virtual Activity_Data Data { get; set; }
        
    }

    public abstract class Activity
    {
        // statt fester methoden, behaviours -> erweiterbarkeit dadurch besser
        // zB 
        // AddBehavour(Precheck), AddBehavour(Postcheck), AddBehavour(Assert), AddBehavour(Assert)
        // <= doch nicht so gut. Wozu auf diese weiße. Die Activity ist Domänen-bezogen vollständig. 
        // 
        // Nutzen von Rollen (Administrator, User, ...). 
        // Rollen machen in einer IDE-Sinn (konfiguration im Sinne von, diese Activity kann von jeden oder nur einer oder mehrerer Rollen durchgeführt werden.
        // Umsetzung durch Attribute.
        // As<Administrator>().StartWith<Activity1>().And<Activity2>();
        // Dann bei AddBehavour<User>(DoActivity) -> die activität wird nur für die Rolle "User" ausgeführt
        // 
        // Enablers
        // Enablers werden einer Activity hinzugefügt, so kann man festlegen, was nach einer Activität für folgeaktivitäten folgen können.
        // Macht nur über eine IDE-Sinn (mit einem Designer). Umsetzung durch Attribute
        //
        // Ausprägungen (begriff finden)
        // zum beispiel "SucheStadt" -> über suchbutton, über schnellstartleiste 
        // Man kann eine Activity über verschiedene ausprägungen laufne lassen (selbe datenbasis), verschiedene wegen über ui
        // alle haben verschiedene wege aber das selbe ziel (daher pre und postchecks sind gleich)
        //
        // Setting (nicht teil der Activity)
        // Ein environment/setting besteht aus einem Initialize und Cleanup Teil. Diese werden, genauso wie die Rolle dem konkreten
        // UseCase test hinzugefügt. -> MUSS ÜBERARBEITET WERDEN, NICHT VON TYP abhängig sondern von einem Key. Die Activity sollte wiessen welche Resource sie braucht durch 
        // einen String oder so Key. 
        // Warum nicht als Data der Activity übergeben? Weil es jede Activty benötigt, es ist Teil der Umgebung des Tests und
        // hat nichts mit der fachlichkeit der Activty zu tun -> zum environment gehört der ChromeBrowser mit eingestellter Homepage-Url
        // Zur Activty-Data gehört eine bestimmte Url-Path jenseits der home-Url


        public virtual bool Precheck()
        {   
            return true;
        }

        public virtual bool Postcheck()
        {
            return true;
        }

        public virtual void Assert(Assertion assertionHandler)
        { }

        public virtual void DoActivity() 
        { }

        public Setting TestSetting { get; set; }

        public Activity_Log Log { get; set; }
    }
}

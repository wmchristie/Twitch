using System.Collections.Generic;
using TechTalk.SpecFlow;
using System.Diagnostics;

namespace Twitch.Spec
{
    [Binding]
    public class ShowListOfRunningApplicationsSteps
    {
        private static List<Process> _openedProcesses;

        private static List<Process> OpenedProcesses
        {
            get { return _openedProcesses ?? (_openedProcesses = new List<Process>()); }
        }

        [AfterScenario]
        public void CloseNotepadProcesses()
        {

            foreach (var process in OpenedProcesses)
            {
                process.Kill();
            }

            OpenedProcesses.Clear();

        }

        [Given(@"notepad is opened on (.*)")]
        public void GivenNotepadIsOpenedOnTestfile_Txt(string filename)
        {
            var process = Process.Start(new ProcessStartInfo
            {
                FileName = "Notepad.exe"
            });

            OpenedProcesses.Add(process);
        }
        
        [When(@"the chord is pressed")]
        public void WhenTheChordIsPressed()
        {
            // Todo: how to send the keys
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"a window is displayed that lists the running applications")]
        public void ThenAWindowIsDisplayedThatListsTheRunningApplications()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the list of running applications is sorted in descending order of most recent activation")]
        public void ThenTheListOfRunningApplicationsIsSortedInDescendingOrderOfMostRecentActivation()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"each item in the list or running applications displays a number from (.*) to Z \(base (.*)\)")]
        public void ThenEachItemInTheListOrRunningApplicationsDisplaysANumberFromToZBase(int p0, int p1)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"the (.*) key is pressed")]
        public void WhenTheKeyIsPressed(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the application instance assigned the number (.*) is activated")]
        public void ThenTheApplicationInstanceAssignedTheNumberIsActivated(int p0)
        {
            ScenarioContext.Current.Pending();
        }

    }
}

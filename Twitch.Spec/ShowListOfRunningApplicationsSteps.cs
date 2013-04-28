using TechTalk.SpecFlow;

namespace Twitch.Spec
{
    [Binding]
    public class ShowListOfRunningApplicationsSteps
    {
        [Given(@"notepad is opened on testfile(.*)\.txt")]
        public void GivenNotepadIsOpenedOnTestfile_Txt(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"the chord is pressed")]
        public void WhenTheChordIsPressed()
        {
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

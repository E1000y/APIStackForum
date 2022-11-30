using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceUWP
{
  public class DataVM
    {
        private readonly ObservableCollection<SubjectBO> _subject = new ObservableCollection<SubjectBO>();
        private readonly ObservableCollection<AnswerBO> _answer = new ObservableCollection<AnswerBO>();
        public ObservableCollection<SubjectBO> Subjects
        {
            get { return _subject; }
        }
        public ObservableCollection<AnswerBO> Answers
        {
            get { return _answer; }
        }



        public async Task<bool> GetSubjects(int CategoryId)
        {
            var subjects = await DataM.Instance.GetSubject(CategoryId);

            if (subjects != null)
            {
                Subjects.Clear();
                subjects.ForEach(x => Subjects.Add(x));
                return true;
            }

            return false;
        }
        public async Task<bool> GetAnswers(int SubjectId)
        {
            var answers = await DataM.Instance.GetAnswer(SubjectId);
            Answers.Clear();

            if (answers != null)
            {
                
                answers.ForEach(x => Answers.Add(x));
                return true;
            }

            return false;
        }

        public void RefreshAnswers()
        {
            Answers.Clear();
        }

        public void RefreshSubject()
        {
            Subjects.Clear();
        }
    }

}


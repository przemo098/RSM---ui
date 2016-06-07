using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OverUnderSample
{
    public class DataModificator
    {
        private int _classIndex;

        private int _disproportion;
        public KeyValuePair<string, int> BiggestClass;
        public List<string> Classes;

        //Key is Class Name and Value is Count Class element
        public Dictionary<string, int> ClassInfo;
        public KeyValuePair<string, int> SmallestClass;


        public void ProcessData(List<List<string>> CSV)
        {
            ClassInfo = new Dictionary<string, int>();

            _classIndex = CSV[0].IndexOf(" Class");


            Classes = CSV.Select(x => x[_classIndex]).Distinct().ToList();
            Classes.Remove(" Class");

            foreach (var @class in Classes)
            {
                ClassInfo.Add(@class, CSV.Select(x => x[_classIndex]).Count(a => a == @class));
            }


            BiggestClass = ClassInfo.FirstOrDefault(x => x.Value == ClassInfo.Max(ci => ci.Value));
            SmallestClass = ClassInfo.FirstOrDefault(x => x.Value == ClassInfo.Min(ci => ci.Value));

            _disproportion = BiggestClass.Value - SmallestClass.Value;
        }


        public void RadomOverSample(List<List<string>> csv)
        {
            ProcessData(csv);

            var classToOverSample = csv.Where(x => x[_classIndex] == SmallestClass.Key).ToList();
            var rnd = new Random();

            for (var i = 0; i < _disproportion; i++)
            {
                var index = rnd.Next(1, classToOverSample.Count);
                csv.Add(classToOverSample[index]);
            }
        }


        public void RandomUnderSample(List<List<string>> csv)
        {
            ProcessData(csv);

            var rnd = new Random();

            for (var i = 0; i < _disproportion; i++)
            {
                var classToUnderSample = csv.Where(x => x[_classIndex] == BiggestClass.Key).ToList();
                var index = rnd.Next(1, classToUnderSample.Count);
                csv.Remove(classToUnderSample[index]);
            }
        }


        public List<string> ToStringList(List<List<string>> csv, char dataSeprator, bool addSpace = true)
        {
            var stringList = new List<string>();

            foreach (var elements in csv)
            {
                var line = string.Empty;
                var sb = new StringBuilder();


                foreach (var element in elements)
                {
                    sb.Append(element);

                    if (element != elements.ElementAt(elements.Count - 1))
                    {
                        sb.Append(dataSeprator);

                        if (addSpace)
                        {
                            sb.Append(" ");
                        }
                    }
                }

                stringList.Add(sb.ToString());
            }

            return stringList;
        }
    }
}
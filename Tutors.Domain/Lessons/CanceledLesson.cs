using System;
using System.Collections.Generic;
using System.Text;

namespace Tutors.Domain
{
    /// <summary>
    /// Данные об отмененном занятии
    /// </summary>
    public class CanceledLesson : IEquatable<CanceledLesson>
    {
        /// <summary>
        /// День занятий
        /// </summary>
        public DateTime LessonDate { get; set; }

        public bool Equals(CanceledLesson other)
        {
            return this.LessonDate.Date == other.LessonDate.Date;
        }

        public override bool Equals(object obj)
        {
            if(obj == null)
            {
                return base.Equals(obj);
            }
            if(obj is CanceledLesson)
            {
                return Equals(obj as CanceledLesson);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return this.LessonDate.Date.GetHashCode();
        }

        public static bool operator ==(CanceledLesson c1, CanceledLesson c2)
        {
            return c1.Equals(c2);
        }

        public static bool operator !=(CanceledLesson c1, CanceledLesson c2)
        {
            return !c1.Equals(c2);
        }
    }
}

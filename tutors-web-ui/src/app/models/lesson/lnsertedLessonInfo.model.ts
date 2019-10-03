/**  Иформация об добавленном уроке*/
export interface insertedLessonInfo{
    /** Дата и время начала занятий*/
    lessonsDateTime: Date;
    /** Продолжительность занятий*/
    lessonsDuration: number;
}
/** Данные о занятии по расписанию */
export interface scheduleLesson {
    /** День занятий */
    lessonDay: number;
    /** Время начала занятий */
    lessonTime: any;
    /** Продолжительность занятий */
    lessonsDuration: number;
}
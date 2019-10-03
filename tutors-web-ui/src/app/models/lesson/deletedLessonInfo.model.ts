/**Информация об отмененом уроке */
export interface deletedLessonInfo {
    /** Тип урока (по плану или добавленный)*/
    lessonType: number;
    /**Id урока (только для лобавленных) */
    id?: number;
    /**День занятий (для тех что по плану) */
    lessonDate?: Date;
}
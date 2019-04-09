declare module server {
	/** Данные о занятии по расписанию */
	interface scheduleLesson {
		/** День занятий */
		lessonDay: number;
		/** Время начала занятий */
		lessonTime: any;
		/** Продолжительность занятий */
		lessonsDuration: number;
	}
}

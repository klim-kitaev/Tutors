declare module server {
	/** Данные о занятии */
	interface lessonInfo {
		/** Дата начала занятия */
		startDate: Date;
		/** Дата начала занятия */
		startDateStr: string;
		/** Дата конца занятия */
		endDate: Date;
		/** Дата конца занятия */
		endDateStr: string;
		/** Цена занятия */
		price: number;
		/** Id ученика */
		pupilId: number;
		/** Имя ученика */
		pupilName: string;
		/** Тип урока */
		lessonInfoType: any;
		lessonDuration: number;
	}
}

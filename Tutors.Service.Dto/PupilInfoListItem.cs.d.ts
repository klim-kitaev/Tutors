declare module server {
	/** Данные об ученике (в списке Учеников) */
	interface pupilInfoListItem {
		id: number;
		/** Краткое имя ученика */
		name: string;
		/** Время занятия в понедельник */
		timeInMonday: string;
		/** Время занятия в вторник */
		timeInTuesday: string;
		/** Время занятия в среду */
		timeInWednesday: string;
		/** Время занятия в четверг */
		timeInThursday: string;
		/** Время занятия в пятницу */
		timeInFirday: string;
		/** Время занятия в субботу */
		timeInSaturday: string;
		/** Время занятия в воскресенье */
		timeInSunday: string;
	}
}

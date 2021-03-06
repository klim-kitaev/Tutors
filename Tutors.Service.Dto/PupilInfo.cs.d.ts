declare module server {
	/** Данные об ученике */
	interface pupilInfo {
		id: number;
		/** Имя */
		firstName: string;
		/** Фамилия */
		lastName: string;
		/** Цена урока за час */
		oneHourPrice?: number;
		/** Цена урока за полтора часа */
		oneAndHalfPrice?: number;
		/** Цена урока за два часа */
		twoHourPrice?: number;
		/** Расписание занятий */
		pupilSchedule: {
		/** Список занятий по расписанию */
			scheduleLessons: any[];
		};
	}
}

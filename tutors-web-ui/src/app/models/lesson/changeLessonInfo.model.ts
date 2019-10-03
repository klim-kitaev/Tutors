import { insertedLessonInfo } from './lnsertedLessonInfo.model';
import { deletedLessonInfo } from './deletedLessonInfo.model';

/**Информация об изменном уроке */
export interface changeLessonInfo {
    /**Id ученика */
    pupilId: number;
    /**Иформация об добавленном уроке */
    insertedInfo?: insertedLessonInfo
    /**Информация об отмененом уроке */
    deletedInfo?: deletedLessonInfo
}
import {Employment} from "../enums/Employment";
import {Purpose} from "../enums/Purpose";
import {Deposit} from "../enums/Deposit";

export interface ICreditDataObject {
    name: string;
    surname: string;
    patronymic: string;
    passportSeries: string;
    passportNumber: string;
    passportIssuer: string;
    passportIssueDate: Date;
    passportRegInformation: string;
    adult: number;
    isJudged: boolean;
    purpose: Purpose;
    employment: Employment;
    deposit: Deposit;
    hasOtherCredits: boolean;
    carAge: number;
    amount: number;
}
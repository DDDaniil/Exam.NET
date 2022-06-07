import {
    AdultMax,
    AdultMin,
    AmountMax,
    AmountMin,
    CarAgeMax,
    CarAgeMin,
    NameMaxLength,
    NameMinLength,
    PassportIssuerMaxLength,
    PassportIssuerMinLength,
    PassportNumberLength,
    PassportRegInformationMaxLength,
    PassportRegInformationMinLength,
    PassportSeriesLength,
    PatronymicMaxLength,
    PatronymicMinLength,
    SurnameMaxLength,
    SurnameMinLength
} from "../variables/Variables";
import {ICreditDataObject} from "../dataobject/ICreditDataObject";
import {Deposit} from "../enums/Deposit";
import {
    IsPassportIssuerValid,
    IsPassportNumberValid,
    IsPassportRegInformationValid,
    IsPassportSeriesValid
} from "./PassportValidator";
import {IsNameValid, IsPatronymicValid, IsSurnameValid} from "./NameValidator";

export const IsCarAgeValid = (value: number) =>
    CarAgeMin <= value && value <= CarAgeMax;

export const IsAdultValid = (value: number) =>
    AdultMin <= value && value <= AdultMax;

export const IsAmountValid = (value: number) =>
    AmountMin <= value && value <= AmountMax;

export function IsCreditDataValid(dataobject: ICreditDataObject) {
    if (!IsSurnameValid(dataobject.surname))
        return `Фамилия введена неправильно. Возможная длина от ${SurnameMinLength} до ${SurnameMaxLength}`;
    if (!IsNameValid(dataobject.name))
        return `Имя введено неправильно. Возможная длина от ${NameMinLength} до ${NameMaxLength}`;
    if (!IsPatronymicValid(dataobject.patronymic))
        return `Отчество введено неправильно. Возможная длина до ${PatronymicMaxLength}`;
    if (!IsPassportSeriesValid(dataobject.passportSeries))
        return `Серия паспорта введена неправильно. Возможная длина ${PassportSeriesLength}`;
    if (!IsPassportNumberValid(dataobject.passportNumber))
        return `Номер паспорта введен неправильно. Возможная длина ${PassportNumberLength}`;
    if (!IsPassportIssuerValid(dataobject.passportIssuer))
        return `Неверный \"кем выдан\". Возможная длина от ${PassportIssuerMinLength} до ${PassportIssuerMaxLength}`;
    if (dataobject.passportIssueDate > new Date())
        return "Дата выдачи введена неправильно";
    if (!IsPassportRegInformationValid(dataobject.passportRegInformation))
        return `Неправильная информация о прописке. 
        Возможная длина от ${PassportRegInformationMinLength} до ${PassportRegInformationMaxLength}`;
    if (!IsCarAgeValid(dataobject.carAge) && dataobject.deposit === Deposit.Car)
        return `Неправильно введен возраст автомобиля. Возможный возраст от ${CarAgeMin} до ${CarAgeMax}`;
    if (!IsAdultValid(dataobject.adult))
        return `Возраст не подходит для кредита. Выдача кредита возможна только лицам от ${AdultMin} до ${AdultMax}`;
    if (!IsAmountValid(dataobject.amount))
        return `Сумма не подходит для кредита. Выдача кредита возможна только от ${AmountMin} до ${AmountMax}`;
    return true;
}
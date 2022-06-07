import React, {useEffect, useState} from 'react';
import {Employment} from "../enums/Employment";
import {Purpose} from "../enums/Purpose";
import {Deposit} from "../enums/Deposit";
import {
    AdultMax,
    AdultMin, AmountMax, AmountMin,
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
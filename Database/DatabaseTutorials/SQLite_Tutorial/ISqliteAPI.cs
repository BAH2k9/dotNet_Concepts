﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite_Tutorial.Models;

namespace SQLite_Tutorial
{
    public interface ISqliteAPI
    {
        List<PersonModel> LoadAllPeople();

        void SavePerson(PersonModel person);

        void CreateDb();
        void DeleteDb();

        void BatchInsert(List<PersonModel> people);

        PersonModel LoadMostRecentPerson();

        List<PersonModel> LoadBatch(int n);

    }
}

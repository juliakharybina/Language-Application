﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

class WordService
{
    private DBClassesDataContext dataContext;

    public WordService(DBClassesDataContext dataContext)
    {
        this.dataContext = dataContext;
    }

    public ICollection<Word> getAll()
    {
        return dataContext.Words.ToList();
    }

    public void create(Word record)
    {
        dataContext.Words.InsertOnSubmit(record);
        dataContext.SubmitChanges();
    }

    public void batchCreate(IList<Word> wordList)
    {
        dataContext.Words.InsertAllOnSubmit(wordList);
        dataContext.SubmitChanges();
    }

    public bool checkIfWordsExistInDb(String word1, String word2)
    {
        return dataContext.Words.Where(w => w.word1 == word1 || w.word1 == word2).ToList().Count() == 0;
    }
}


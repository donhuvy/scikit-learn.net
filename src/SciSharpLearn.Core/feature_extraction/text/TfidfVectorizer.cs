﻿using SciSharp.Core.Sparse;
using System;
using System.Collections.Generic;
using System.Text;

namespace SciSharpLearn.Core.feature_extraction.text
{
    public class TfidfVectorizer : CountVectorizer
    {
        public TfidfTransformer _tfidf { get; set; }

        public TfidfVectorizer()
        {
            _tfidf = new TfidfTransformer();
        }

        public csr_matrix fit_transform(string[] corpus)
        {
            var (vocabulary, X) = _count_vocab(corpus);
            X = _sort_features(X, vocabulary);

            int max_doc_count = X.shape[0];
            int min_doc_count = min_df;

            _limit_features(X, vocabulary, max_doc_count, min_doc_count);
            _tfidf.fit(X);

            return X;
        }
    }
}

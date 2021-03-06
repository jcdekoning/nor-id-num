﻿using System;
using System.Collections.Generic;
using System.Linq;
using NinEngine;
using NUnit.Framework;

namespace UnitTest
{
    [TestFixture]
    public class DNumberTest
    {
        #region Test data

        private const string NumberNull = null;
        private const string NumberEmpty = "";
        private const string NumberShort = "1234567890";
        private const string NumberLong = "123456789012";
        private const string NumberNonDigit1 = "A2345678901";
        private const string NumberNonDigit2 = "1b345678901";
        private const string NumberNonDigit3 = "12Ø45678901";
        private const string NumberNonDigit4 = "123å5678901";
        private const string NumberNonDigit5 = "1234!678901";
        private const string NumberNonDigit6 = "12345~78901";
        private const string NumberBadDate1 = "40019912345";
        private const string NumberBadDate2 = "72019912345";
        private const string NumberBadDate3 = "71049912345";
        private const string NumberBadDate4 = "69029912345";
        private const string NumberBadDate5 = "41009912345";
        private const string NumberBadDate6 = "41139912345";
        private const string NumberBadDate7 = "41139912345";
        private const string NumberBadYearAndIndividualNumberCombination = "41014567845";
        private const string NumberBadFirstCheckDigit1 = "41020398700";
        private const string NumberBadFirstCheckDigit2 = "41020398710";
        private const string NumberBadFirstCheckDigit3 = "41020398720";
        private const string NumberBadFirstCheckDigit4 = "41020398730";
        private const string NumberBadFirstCheckDigit5 = "41020398740";
        private const string NumberBadFirstCheckDigit6 = "41020398760";
        private const string NumberBadFirstCheckDigit7 = "41020398770";
        private const string NumberBadFirstCheckDigit8 = "41020398780";
        private const string NumberBadFirstCheckDigit9 = "41020398790";
        private const string NumberBadSecondCheckDigit1 = "41020398751";
        private const string NumberBadSecondCheckDigit2 = "41020398752";
        private const string NumberBadSecondCheckDigit3 = "41020398753";
        private const string NumberBadSecondCheckDigit4 = "41020398754";
        private const string NumberBadSecondCheckDigit5 = "41020398755";
        private const string NumberBadSecondCheckDigit6 = "41020398756";
        private const string NumberBadSecondCheckDigit7 = "41020398757";
        private const string NumberBadSecondCheckDigit8 = "41020398758";
        private const string NumberBadSecondCheckDigit9 = "41020398759";
        private const string NumberLegal = "41020398750";

        #endregion Test data

        #region Fast tests

        [Category(TestCategory.Fast)]
        [Test]
        public void Construct_Null_ThrowsException()
        {
            var ex = Assert.Throws(typeof(NinException), () => new DNumber(NumberNull));
            NinException nex = ex as NinException;
            Assert.IsNotNull(nex);
            Assert.AreEqual(Statuscode.IsNullOrEmpty, nex.Code);
        }

        [Category(TestCategory.Fast)]
        [Test]
        public void Construct_Empty_ThrowsException()
        {
            var ex = Assert.Throws(typeof(NinException), () => new DNumber(NumberEmpty));
            NinException nex = ex as NinException;
            Assert.IsNotNull(nex);
            Assert.AreEqual(Statuscode.IsNullOrEmpty, nex.Code);
        }

        [Category(TestCategory.Fast)]
        [Test]
        public void Construct_TooShort_ThrowsException()
        {
            var ex = Assert.Throws(typeof(NinException), () => new DNumber(NumberShort));
            NinException nex = ex as NinException;
            Assert.IsNotNull(nex);
            Assert.AreEqual(Statuscode.BadLength, nex.Code);
        }

        [Category(TestCategory.Fast)]
        [Test]
        public void Construct_TooLong_ThrowsException()
        {
            var ex = Assert.Throws(typeof(NinException), () => new DNumber(NumberLong));
            NinException nex = ex as NinException;
            Assert.IsNotNull(nex);
            Assert.AreEqual(Statuscode.BadLength, nex.Code);
        }

        [Category(TestCategory.Fast)]
        [TestCase(NumberNonDigit1)]
        [TestCase(NumberNonDigit2)]
        [TestCase(NumberNonDigit3)]
        [TestCase(NumberNonDigit4)]
        [TestCase(NumberNonDigit5)]
        [TestCase(NumberNonDigit6)]
        public void Construct_NonDigits_ThrowsException(string number)
        {
            var ex = Assert.Throws(typeof(NinException), () => new DNumber(number));
            NinException nex = ex as NinException;
            Assert.IsNotNull(nex);
            Assert.AreEqual(Statuscode.BadCharacters, nex.Code);
        }

        [Category(TestCategory.Fast)]
        [TestCase(NumberBadDate1)]
        [TestCase(NumberBadDate2)]
        [TestCase(NumberBadDate3)]
        [TestCase(NumberBadDate4)]
        [TestCase(NumberBadDate5)]
        [TestCase(NumberBadDate6)]
        [TestCase(NumberBadDate7)]
        public void Construct_BadDate_ThrowsException(string number)
        {
            var ex = Assert.Throws(typeof(NinException), () => new DNumber(number));
            NinException nex = ex as NinException;
            Assert.IsNotNull(nex);
            Assert.AreEqual(Statuscode.BadDate, nex.Code);
        }

        [Category(TestCategory.Fast)]
        [TestCase(NumberBadYearAndIndividualNumberCombination)]
        public void Construct_BadYearAndIndividualNumberCombination_ThrowsException(string number)
        {
            var ex = Assert.Throws(typeof(NinException), () => new DNumber(number));
            NinException nex = ex as NinException;
            Assert.IsNotNull(nex);
            Assert.AreEqual(Statuscode.BadYearAndIndividualNumberCombination, nex.Code);
        }

        [Category(TestCategory.Fast)]
        [TestCase(NumberBadFirstCheckDigit1)]
        [TestCase(NumberBadFirstCheckDigit2)]
        [TestCase(NumberBadFirstCheckDigit3)]
        [TestCase(NumberBadFirstCheckDigit4)]
        [TestCase(NumberBadFirstCheckDigit5)]
        [TestCase(NumberBadFirstCheckDigit6)]
        [TestCase(NumberBadFirstCheckDigit7)]
        [TestCase(NumberBadFirstCheckDigit8)]
        [TestCase(NumberBadFirstCheckDigit9)]
        public void Construct_BadFirstCheckDigit_ThrowsException(string number)
        {
            var ex = Assert.Throws(typeof(NinException), () => new DNumber(number));
            NinException nex = ex as NinException;
            Assert.IsNotNull(nex);
            Assert.AreEqual(Statuscode.BadCheckDigit, nex.Code);
        }

        [Category(TestCategory.Fast)]
        [TestCase(NumberBadSecondCheckDigit1)]
        [TestCase(NumberBadSecondCheckDigit2)]
        [TestCase(NumberBadSecondCheckDigit3)]
        [TestCase(NumberBadSecondCheckDigit4)]
        [TestCase(NumberBadSecondCheckDigit5)]
        [TestCase(NumberBadSecondCheckDigit6)]
        [TestCase(NumberBadSecondCheckDigit7)]
        [TestCase(NumberBadSecondCheckDigit8)]
        [TestCase(NumberBadSecondCheckDigit9)]
        public void Construct_BadSecondCheckDigit_ThrowsException(string number)
        {
            var ex = Assert.Throws(typeof(NinException), () => new DNumber(number));
            NinException nex = ex as NinException;
            Assert.IsNotNull(nex);
            Assert.AreEqual(Statuscode.BadCheckDigit, nex.Code);
        }

        [Category(TestCategory.Fast)]
        [TestCase(NumberLegal)]
        public void Construct_Legal_PropertiesSet(string number)
        {
            DNumber dn = new DNumber(number);
            Assert.AreEqual("D-nummer", dn.Name);
            Assert.AreEqual(number, dn.Number);
        }

        [Category(TestCategory.Fast)]
        [TestCase(NumberNull)]
        [TestCase(NumberEmpty)]
        [TestCase(NumberShort)]
        [TestCase(NumberLong)]
        [TestCase(NumberNonDigit1)]
        [TestCase(NumberNonDigit2)]
        [TestCase(NumberNonDigit3)]
        [TestCase(NumberNonDigit4)]
        [TestCase(NumberNonDigit5)]
        [TestCase(NumberNonDigit6)]
        [TestCase(NumberBadDate1)]
        [TestCase(NumberBadDate2)]
        [TestCase(NumberBadDate3)]
        [TestCase(NumberBadDate4)]
        [TestCase(NumberBadDate5)]
        [TestCase(NumberBadDate6)]
        [TestCase(NumberBadDate7)]
        [TestCase(NumberBadYearAndIndividualNumberCombination)]
        [TestCase(NumberBadFirstCheckDigit1)]
        [TestCase(NumberBadFirstCheckDigit2)]
        [TestCase(NumberBadFirstCheckDigit3)]
        [TestCase(NumberBadFirstCheckDigit4)]
        [TestCase(NumberBadFirstCheckDigit5)]
        [TestCase(NumberBadFirstCheckDigit6)]
        [TestCase(NumberBadFirstCheckDigit7)]
        [TestCase(NumberBadFirstCheckDigit8)]
        [TestCase(NumberBadFirstCheckDigit9)]
        [TestCase(NumberBadSecondCheckDigit1)]
        [TestCase(NumberBadSecondCheckDigit2)]
        [TestCase(NumberBadSecondCheckDigit3)]
        [TestCase(NumberBadSecondCheckDigit4)]
        [TestCase(NumberBadSecondCheckDigit5)]
        [TestCase(NumberBadSecondCheckDigit6)]
        [TestCase(NumberBadSecondCheckDigit7)]
        [TestCase(NumberBadSecondCheckDigit8)]
        [TestCase(NumberBadSecondCheckDigit9)]
        public void Create_Illegal_ReturnsNull(string number)
        {
            DNumber dn = DNumber.Create(number);
            Assert.IsNull(dn);
        }

        [Category(TestCategory.Fast)]
        [TestCase(NumberLegal)]
        public void Create_Legal_ReturnsObjectWithPropertiesSet(string number)
        {
            DNumber dn = DNumber.Create(number);
            Assert.IsNotNull(dn);
            Assert.AreEqual("D-nummer", dn.Name);
            Assert.AreEqual(number, dn.Number);
        }

        [Category(TestCategory.Fast)]
        [Test]
        public void OneRandom_ReturnsValidNumber()
        {
            Assert.DoesNotThrow(() => DNumber.OneRandom());
        }

        [Category(TestCategory.Fast)]
        [Test]
        public void OneRandom_TwoCallsReturnsDifferentNumbers()
        {
            DNumber dNo1 = DNumber.OneRandom();
            DNumber dNo2 = DNumber.OneRandom();
            Assert.IsNotNull(dNo1);
            Assert.IsNotNull(dNo2);
            Assert.AreNotEqual(dNo1.Number, dNo2.Number);
        }

        [Category(TestCategory.Fast)]
        [Test]
        public void OneRandom_NullPattern_ThrowsException()
        {
            var ex = Assert.Throws(typeof(NinException), () => DNumber.OneRandom(null));
            NinException nex = ex as NinException;
            Assert.IsNotNull(nex);
            Assert.AreEqual(Statuscode.PatternIsNullOrEmpty, nex.Code);
        }

        [Category(TestCategory.Fast)]
        [Test]
        public void OneRandom_EmptyPattern_ThrowsException()
        {
            var ex = Assert.Throws(typeof(NinException), () => DNumber.OneRandom(string.Empty));
            NinException nex = ex as NinException;
            Assert.IsNotNull(nex);
            Assert.AreEqual(Statuscode.PatternIsNullOrEmpty, nex.Code);
        }

        [Category(TestCategory.Fast)]
        [TestCase("??????????")]
        [TestCase("????????????")]
        public void OneRandom_BadLengthPattern_ThrowsException(string pattern)
        {
            var ex = Assert.Throws(typeof(NinException), () => DNumber.OneRandom(pattern));
            NinException nex = ex as NinException;
            Assert.IsNotNull(nex);
            Assert.AreEqual(Statuscode.BadPatternLength, nex.Code);
        }

        [Category(TestCategory.Fast)]
        [TestCase("C??????????")]
        [TestCase("?d?????????")]
        [TestCase("??Æ????????")]
        [TestCase("???ø???????")]
        [TestCase("????#??????")]
        [TestCase("?????|?????")]
        public void OneRandom_InvalidCharacterInPattern_ThrowsException(string pattern)
        {
            var ex = Assert.Throws(typeof(NinException), () => DNumber.OneRandom(pattern));
            NinException nex = ex as NinException;
            Assert.IsNotNull(nex);
            Assert.AreEqual(Statuscode.BadPattern, nex.Code);
        }

        [Category(TestCategory.Fast)]
        [Test]
        public void OneRandom_NoWildcardInPattern_ThrowsException()
        {
            var ex = Assert.Throws(typeof(NinException), () => DNumber.OneRandom("01234567890"));
            NinException nex = ex as NinException;
            Assert.IsNotNull(nex);
            Assert.AreEqual(Statuscode.BadPattern, nex.Code);
        }

        [Category(TestCategory.Fast)]
        [TestCase("???????????")]
        [TestCase("31?????????")]
        [TestCase("??12???????")]
        [TestCase("????99?????")]
        [TestCase("??????999??")]
        [TestCase("?????????0?")]
        [TestCase("??????????0")]
        [TestCase("?????????99")]
        public void OneRandom_GoodPattern_ReturnsValidNumber(string pattern)
        {
            Assert.DoesNotThrow(() => DNumber.OneRandom(pattern));
        }

        [Category(TestCategory.Fast)]
        [Test]
        public void OneRandom_BadFromDate_ThrowsException()
        {
            var ex = Assert.Throws(typeof(NinException), () => DNumber.OneRandom(DateBasedIdNumber.FirstPossible.AddDays(-1), DateBasedIdNumber.LastPossible));
            NinException nex = ex as NinException;
            Assert.IsNotNull(nex);
            Assert.AreEqual(Statuscode.BadDate, nex.Code);
        }

        [Category(TestCategory.Fast)]
        [Test]
        public void OneRandom_BadToDate_ThrowsException()
        {
            var ex = Assert.Throws(typeof(NinException), () => DNumber.OneRandom(DateBasedIdNumber.FirstPossible, DateBasedIdNumber.LastPossible.AddDays(1)));
            NinException nex = ex as NinException;
            Assert.IsNotNull(nex);
            Assert.AreEqual(Statuscode.BadDate, nex.Code);
        }

        [Category(TestCategory.Fast)]
        [Test]
        public void OneRandom_FromDateLaterThanToDate_ThrowsException()
        {
            var ex = Assert.Throws(typeof(NinException), () => DNumber.OneRandom(DateBasedIdNumber.LastPossible, DateBasedIdNumber.FirstPossible));
            NinException nex = ex as NinException;
            Assert.IsNotNull(nex);
            Assert.AreEqual(Statuscode.BadDate, nex.Code);
        }

        [Category(TestCategory.Fast)]
        [TestCase(GenderRequest.Female, 0)]
        [TestCase(GenderRequest.Male, 1)]
        public void OneRandom_SpecificGender_ReturnsOnlySpecifiedGender(GenderRequest gender, int expectedOddOrEven)
        {
            for (int index = 0; index < 10; ++index)
            {
                DNumber dNo = DNumber.OneRandom(DateBasedIdNumber.FirstPossible, DateBasedIdNumber.LastPossible, gender);
                Assert.IsNotNull(dNo);
                int oddOrEven = dNo.Number[8] & 1;
                Assert.AreEqual(expectedOddOrEven, oddOrEven);
            }
        }

        [Category(TestCategory.Fast)]
        [TestCase(GenderRequest.Any)]
        [TestCase(GenderRequest.Female)]
        [TestCase(GenderRequest.Male)]
        public void OneRandom_SpecificYear_ReturnsValidIndividualNumber(GenderRequest gender)
        {
            int firstYear = DateBasedIdNumber.FirstPossible.Year;
            int lastYear = DateBasedIdNumber.LastPossible.Year;
            for (int year = firstYear; year < lastYear; ++year)
            {
                IEnumerable<int> legalIndividualNumbers = IndividualNumberProvider.GetLegalNumbers(year, gender);
                DateTime dateFrom = new DateTime(year, 1, 1);
                DateTime dateTo = new DateTime(year, 12, 31);
                DNumber dNumber = DNumber.OneRandom(dateFrom, dateTo, gender);
                if (null != dNumber)
                {
                    int individualNumber = int.Parse(dNumber.Number.Substring(6, 3));
                    Assert.IsTrue(legalIndividualNumbers.Contains(individualNumber));
                }
            }
        }

        [Category(TestCategory.Fast)]
        [TestCase(123)]
        [TestCase(987)]
        public void QuickManyRandom_ReturnsRequestedNumber(int count)
        {
            List<DNumber> many = DNumber.QuickManyRandom(count).ToList();
            Assert.IsNotNull(many);
            Assert.AreEqual(count, many.Count);
        }

        #endregion Fast tests

        #region Slow tests

        [Category(TestCategory.Slow)]
        [TestCase(123)]
        [TestCase(987)]
        public void ManyRandom_ReturnsRequestedNumber(int count)
        {
            List<DNumber> many = DNumber.ManyRandom(count).ToList();
            Assert.IsNotNull(many);
            Assert.AreEqual(count, many.Count);
        }

        [Category(TestCategory.Slow)]
        [Test]
        public void ManyRandom_TooManyRequested_ReturnsMaximumNumber()
        {
            List<DNumber> many = DNumber.ManyRandom(DNumber.PossibleLegalVariations + 123).ToList();
            Assert.IsNotNull(many);
            Assert.AreEqual(DNumber.PossibleLegalVariations, many.Count);
        }

        [Category(TestCategory.Slow)]
        [Test]
        public void AllPossible_ReturnsAllPossibleVariations()
        {
            List<DNumber> allPossible = DNumber.AllPossible().ToList();
            Assert.IsNotNull(allPossible);
            Assert.AreEqual(DNumber.PossibleLegalVariations, allPossible.Count);
            Assert.AreEqual("41015450051", allPossible[0].Number);
            Assert.AreEqual("71123999929", allPossible[DNumber.PossibleLegalVariations - 1].Number);
        }

        #endregion Slow tests
    }
}

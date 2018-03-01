import unittest
import NameExtractor


class TestNameExtractor(unittest.TestCase):

    @classmethod
    def setUpClass(cls):
        print 'setUpClass'

    @classmethod
    def tearDownClass(cls):
        print 'tearDownClass'

    def setUp(self):
        print 'Set up'
        self.value = NameExtractor.NameExtractor()
        self.value.full_name = 'Mr John Brown'
        self.value._parse_name()

        self.value1 = NameExtractor.NameExtractor()
        self.value1.full_name = 'Mr. John Paul Brown Phd'
        self.value1._parse_name()

        self.value2 = NameExtractor.NameExtractor()
        self.value2.full_name = 'John Brown'
        self.value2._parse_name()

        self.value3 = NameExtractor.NameExtractor()
        self.value3.full_name = 'Mr.    John Brown'
        self.value3._parse_name()

        self.value4 = NameExtractor.NameExtractor()
        self.value4.full_name = 'John Brown, PhD'
        self.value4._parse_name()

    def tearDown(self):
        print 'Tear Down'

    def test_full_name(self):
        print 'test full_name'
        self.assertEqual(self.value.full_name, 'Mr John Brown', 'Full name is '
                                                                'not correct')
        self.assertEqual(self.value1.full_name, 'Mr. John Paul Brown Phd',
                         'Full name is not correct')
        self.assertEqual(self.value2.full_name, 'John Brown',
                         'Full name is not correct')
        self.assertEqual(self.value3.full_name, 'Mr.    John Brown',
                         'Full name is not correct')
        self.assertEqual(self.value4.full_name, 'John Brown, PhD',
                         'Full name is not correct')

    def test_title(self):
        print 'test title'
        self.assertEqual(self.value.title(), 'Mr', 'Title is not correct')
        self.assertEqual(self.value1.title(), 'Mr', 'Title is not correct')
        self.assertEqual(self.value2.title(), '', 'Title is not correct')
        self.assertEqual(self.value3.title(), 'Mr', 'Title is not correct')

    def test_first_name(self):
        print 'test first_name'
        self.assertEqual(self.value.first_name(), 'John',
                         'First Name is not correct')
        self.assertEqual(self.value1.first_name(), 'John',
                         'First Name is not correct')
        self.assertEqual(self.value2.first_name(), 'John',
                         'First Name is not correct')
        self.assertEqual(self.value3.first_name(), 'John',
                         'First Name is not correct')
        self.assertEqual(self.value4.first_name(), 'John',
                         'First Name is not correct')

    def test_middle_name(self):
        print 'test middle_name'
        self.assertEqual(self.value.middle_name(), '', 'Middle Name is not '
                                                       'correct')
        self.assertEqual(self.value1.middle_name(), 'Paul', 'Middle Name is '
                                                            'not correct')
        self.assertEqual(self.value2.middle_name(), '', 'Middle Name is '
                                                        'not correct')
        self.assertEqual(self.value3.middle_name(), '', 'Middle Name is '
                                                        'not correct')

    def test_last_name(self):
        print 'test last_name'
        self.assertEqual(self.value.last_name(), 'Brown', 'Last Name is not '
                                                          'correct')
        self.assertEqual(self.value1.last_name(), 'Brown', 'Last Name is not '
                                                           'correct')
        self.assertEqual(self.value2.last_name(), 'Brown', 'Last Name is not '
                                                           'correct')
        self.assertEqual(self.value3.last_name(), 'Brown', 'Last Name is not '
                                                           'correct')
        self.assertEqual(self.value4.last_name(), 'Brown', 'Last Name is not '
                                                           'correct')

    def test_suffix(self):
        print 'test suffix_name'
        self.assertEqual(self.value.suffix(), '', 'Suffix is not correct')
        self.assertEqual(self.value1.suffix(), 'Phd', 'Suffix is not correct')
        self.assertEqual(self.value2.suffix(), '', 'Suffix is not correct')
        self.assertEqual(self.value3.suffix(), '', 'Suffix is not correct')
        self.assertEqual(self.value4.suffix(), 'PhD', 'Suffix is not correct')


if __name__ == '__main__':
    unittest.main()

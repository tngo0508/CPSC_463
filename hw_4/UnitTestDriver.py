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

    def tearDown(self):
        print 'Tear Down'

    def test_full_name(self):
        print 'test full_name'
        self.assertEqual(self.value.full_name, 'Mr John Brown')
        self.assertEqual(self.value1.full_name, 'Mr. John Paul Brown Phd')

    def test_first_name(self):
        print 'test first_name'
        self.assertEqual(self.value.first_name(), 'John')
        self.assertEqual(self.value1.first_name(), 'John')

    def test_title(self):
        print 'test title'
        self.assertEqual(self.value.title(), 'Mr')
        self.assertEqual(self.value1.title(), 'Mr')

    def test_last_name(self):
        print 'test last_name'
        self.assertEqual(self.value.last_name(), 'Brown')
        self.assertEqual(self.value1.last_name(), 'Brown')

    def test_middle_name(self):
        print 'test middle_name'
        self.assertEqual(self.value.middle_name(), '')
        self.assertEqual(self.value1.middle_name(), 'Paul')

    def test_suffix(self):
        self.assertEqual(self.value.suffix(), '')
        self.assertEqual(self.value1.suffix(), 'Phd')


if __name__ == '__main__':
    unittest.main()
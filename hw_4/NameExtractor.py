import unittest
import re


class NameExtractor():
    def __init__(self):
        self._m_full_name = ''
        self._m_title = ''
        self._m_first_name = ''
        self._m_middle_name = ''
        self._m_last_name = ''
        self._m_suffix = ''
        self._m_words = ['']
        self._m_num_words = 0

    @property
    def full_name(self):
        return self._m_full_name

    @full_name.setter
    def full_name(self, m_full_name):
        self._m_full_name = m_full_name

    def title(self):
        return self._m_title

    def first_name(self):
        return self._m_first_name

    def middle_name(self):
        return self._m_middle_name

    def last_name(self):
        return self._m_last_name

    def suffix(self):
        return self._m_suffix

    @staticmethod
    def _extract_words(self, value):
        words = re.findall(r'[^\s,.:\t]+', value)
        if len(words) < 5:
            self._m_num_words = len(words)
            self._m_words = words
        else:
            self._m_num_words = 5
            self._m_words = words[:5]

    def _parse_name(self):
        if self._m_full_name is not None and self._m_full_name is not ' ':
            self._extract_words(self._m_full_name)
            self._find_title()
            self._find_suffix()
            self._find_last_name()
            self._find_first_name()
            self._find_middle_name()

    def _find_title(self):
        title_list = ['Mr.','Mr','Ms.','Ms','Miss.','Miss','Dr.','Dr','Mrs.',
                      'Mrs','Fr.','Capt.','Lt.','Gen.','President','Sister',
                      'Father','Brother','Major']
        if not self._m_words:
            if self._m_words[0] in title_list:
                self._m_title = self._m_words[0]
                return 0
            return -1
        return -1

    def _find_suffix(self):
        suffix_list = ['DDS','CFA','CEO','CFO','Esq','CPA','MBA','PhD','MD',
                       'DC','Sr','Jr','II','III','IV']
        if self._m_words[4] is not None:
            self._m_suffix = self._m_words[4]
            return 0
        else:
            if self._m_words[2] is not None and self._m_words[2] in suffix_list:
                self._m_suffix = self._m_words[2]
                return 0
            if self._m_words[3] is not None and self._m_words[3] in suffix_list:
                self._m_suffix = self._m_words[3]
                return 0
        return -1

    def _find_first_name(self):
        pass

    def _find_middle_name(self):
        pass

    def _find_last_name(self):
        pass


class ENameExtractorError():
    def __init__(self):
        pass

    def e_name_extractor_error(self, message):
        pass


if __name__ == '__main__':
    unittest.main()
##import unittest
import re


class NameExtractor():
    def __init__(self):
        self.__m_full_name = ''
        self.__m_title = ''
        self.__m_first_name = ''
        self.__m_middle_name = ''
        self.__m_last_name = ''
        self.__m_suffix = ''
        self.__m_words = [None]*5
        self.__m_num_words = 0

    @property
    def full_name(self):
        return self.__m_full_name

    @full_name.setter
    def full_name(self, m_full_name):
        self.__m_full_name = m_full_name

    def __set_full_name(self, m_full_name):
        self.full_name = m_full_name

    def title(self):
        return self.__m_title

    def first_name(self):
        return self.__m_first_name

    def middle_name(self):
        return self.__m_middle_name

    def last_name(self):
        return self.__m_last_name

    def suffix(self):
        return self.__m_suffix

    def _extract_words(self, value):
        words = re.findall(r'[^\s,.:\t]+', value)
        if len(words) <= 5:
            self.__m_num_words = len(words)
            self.__m_words[:len(words)] = words
        else:
            self.__m_num_words = 5
            self.__m_words = words[:5]

    def _parse_name(self):
        if self.__m_full_name is not None and self.__m_full_name is not ' ':
            self._extract_words(self.full_name)
            self._find_title()
            self._find_suffix()
            self._find_last_name()
            self._find_first_name()
            self._find_middle_name()

    def _find_title(self):
        title_list = ['Mr.','Mr','Ms.','Ms','Miss.','Miss','Dr.','Dr','Mrs.',
                      'Mrs','Fr.','Capt.','Lt.','Gen.','President','Sister',
                      'Father','Brother','Major']
        if self.__m_words is not None:
            if self.__m_words[0] in title_list:
                self.__m_title = self.__m_words[0]
                return 0
            return -1
        return -1

    def _find_suffix(self):
        suffix_list = ['DDS','CFA','CEO','CFO','Esq','CPA','MBA','PhD','MD',
                       'DC','Sr','Jr','II','III','IV']
        if self.__m_words[4] is not None:
            self.__m_suffix = self.__m_words[4]
            return 0
        else:
            if self.__m_words[2] is not None and self.__m_words[2] in \
                    suffix_list:
                self.__m_suffix = self.__m_words[2]
                return 0
            if self.__m_words[3] is not None and self.__m_words[3] in \
                    suffix_list:
                self.__m_suffix = self.__m_words[3]
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


def main():
    name = NameExtractor()
    name.full_name = 'John Brown'
    print name.full_name
    name._parse_name()
    print name.full_name


if __name__ == '__main__':
    #unittest.main()
    main()
import HomePage from 'components/pages/home-page'
import SoruCevapEkle from 'components/pages/soru-cevap-ekle';
import TestOl from 'components/pages/test-ol';
import Forbidden from 'components/root/forbidden';

export const routes = [
	{
    name: 'home',
    path: '/',
    component: HomePage,
    display: 'Anasayfa',
    icon: 'home'
  },
  {
    divider: true,
    path: ''
  },
  {
    name: 'soru-cevap-ekle',
    path: '/soru/ekle',
    component: SoruCevapEkle,
    display: 'Soru ekle',
    icon: 'plus'
  },
  {
    name: 'test-ol',
    path: '/test/ol/:id?',
    component: TestOl,
    display: 'Test Ol',
    icon: 'pen'
  },
  {
    divider: true,
    path: ''
  },
  {
    name: 'account-view',
    path: '/Identity/Account/Manage',
    display: 'Account',
    icon: 'user-circle'
  },
  {
    name: 'forbidden',
    path: '/forbidden',
    hidden: true,
    component: Forbidden
  }
]

import { useState } from 'react';

const useModal = () => {
  const [modalVisible, setModalVisible] = useState(false);
  const [modalClosing, setModalClosing] = useState(false);
  const [modalData, setModalData] = useState(null);

  const openModal = () => {
    setModalVisible(true);
  };

  const closeModal = () => {
    setModalClosing(true);
    setTimeout(() => {
      setModalVisible(false);
      setModalClosing(false);
      setModalData(null);
    }, 300); // delay for modal close animation
  };

  return { modalVisible, modalClosing, modalData, openModal, closeModal, setModalData };
};

export default useModal;